using ErrorCraft.Nbt.Tags;
using System;
using System.IO;
using System.Text;

namespace ErrorCraft.Nbt {
    /// <summary>
    /// A class for writing binary data to a stream.
    /// </summary>
    public class BinaryWriter : IDisposable {
        private const string TOO_MANY_BYTES_IN_STRING_MESSAGE = "The number of bytes in the UTF-8 string was larger than the maximum allowed ({0})";
        private readonly Encoding Encoding = new ModifiedUTF8Encoding();
        private readonly Stream Stream;
        private readonly byte[] Buffer = new byte[sizeof(long)];

        /// <summary>
        /// Initialises a new instance of the <see cref="BinaryWriter"/> class with the specified stream.
        /// </summary>
        /// <param name="stream">The output stream.</param>
        public BinaryWriter(Stream stream) {
            Stream = stream;
        }

        /// <summary>
        /// Writes a signed byte to the stream.
        /// </summary>
        /// <param name="value">The signed byte to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteByte(sbyte value) {
            Buffer[0] = (byte)value;
            WriteBuffer(1);
        }

        /// <summary>
        /// Writes an unsigned byte to the stream.
        /// </summary>
        /// <param name="value">The unsigned byte to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteUnsignedByte(byte value) {
            WriteByte((sbyte)value);
        }

        /// <summary>
        /// Writes a signed 16-bit integer to the stream.
        /// </summary>
        /// <param name="value">The signed 16-bit integer to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteShort(short value) {
            Buffer[0] = (byte)(value >> 8 & 0xFF);
            Buffer[1] = (byte)(value & 0xFF);
            WriteBuffer(2);
        }

        /// <summary>
        /// Writes an unsigned 16-bit integer to the stream.
        /// </summary>
        /// <param name="value">The unsigned 16-bit integer to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteUnsignedShort(ushort value) {
            WriteShort((short)value);
        }

        /// <summary>
        /// Writes a signed 32-bit integer to the stream.
        /// </summary>
        /// <param name="value">The signed 32-bit integer to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteInt(int value) {
            for (int i = 0; i < 4; i++) {
                Buffer[i] = (byte)(value >> ((3 - i) * 8) & 0xFF);
            }
            WriteBuffer(4);
        }

        /// <summary>
        /// Writes an unsigned 32-bit integer to the stream.
        /// </summary>
        /// <param name="value">The unsigned 32-bit integer to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteUnsignedInt(uint value) {
            WriteInt((int)value);
        }

        /// <summary>
        /// Writes a signed 64-bit integer to the stream.
        /// </summary>
        /// <param name="value">The signed 64-bit integer to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteLong(long value) {
            for (int i = 0; i < 8; i++) {
                Buffer[i] = (byte)(value >> ((7 - i) * 8) & 0xFF);
            }
            WriteBuffer(8);
        }

        /// <summary>
        /// Writes an unsigned 64-bit integer to the stream.
        /// </summary>
        /// <param name="value">The unsigned 64-bit integer to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteUnsignedLong(ulong value) {
            WriteLong((long)value);
        }

        /// <summary>
        /// Writes a single-precision floating point number to the stream.
        /// </summary>
        /// <param name="value">The single-precision floating point number to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public unsafe void WriteFloat(float value) {
            int i = *(int*)&value;
            WriteInt(i);
        }

        /// <summary>
        /// Writes a double-precision floating point number to the stream.
        /// </summary>
        /// <param name="value">The double-precision floating point number to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public unsafe void WriteDouble(double value) {
            long l = *(long*)&value;
            WriteLong(l);
        }

        /// <summary>
        /// Writes a length-prefixed string to the stream using the <see cref="ModifiedUTF8Encoding"/> encoding.
        /// </summary>
        /// <param name="value">The string to write.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
        /// <exception cref="InvalidOperationException">There are too many bytes in the string.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteString(string value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }
            int length = Encoding.GetByteCount(value);
            if (length > ushort.MaxValue) {
                throw new InvalidOperationException(string.Format(TOO_MANY_BYTES_IN_STRING_MESSAGE, ushort.MaxValue));
            }
            WriteUnsignedShort((ushort)length);
            WriteBytes(Encoding.GetBytes(value));
        }

        /// <summary>
        /// Writes a <see cref="TagType"/> to the stream.
        /// </summary>
        /// <param name="value">The <see cref="TagType"/> to write.</param>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public void WriteTagType(TagType value) {
            WriteByte((sbyte)value);
        }

        private void WriteBytes(byte[] bytes) {
            Stream.Write(bytes, 0, bytes.Length);
        }

        private void WriteBuffer(int length) {
            Stream.Write(Buffer, 0, length);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Stream.Dispose();
            }
        }
    }
}
