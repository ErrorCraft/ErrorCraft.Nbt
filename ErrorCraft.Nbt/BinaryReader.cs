using ErrorCraft.Nbt.Tags;
using System;
using System.IO;
using System.Text;

namespace ErrorCraft.Nbt {
    /// <summary>
    /// A class for reading binary data from a stream.
    /// </summary>
    public class BinaryReader : IDisposable {
        private readonly Encoding Encoding = new ModifiedUTF8Encoding();
        private readonly Stream Stream;
        private readonly byte[] Buffer = new byte[sizeof(long)];

        /// <summary>
        /// Initialises a new instance of the <see cref="BinaryReader"/> class with the specified stream.
        /// </summary>
        /// <param name="stream">The input stream.</param>
        public BinaryReader(Stream stream) {
            Stream = stream;
        }

        /// <summary>
        /// Reads the next signed byte from the stream.
        /// </summary>
        /// <returns>The next signed byte read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public sbyte ReadByte() {
            FillBuffer(1);
            return (sbyte)Buffer[0];
        }

        /// <summary>
        /// Reads the next unsigned byte from the stream.
        /// </summary>
        /// <returns>The next unsigned byte read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public byte ReadUnsignedByte() {
            return (byte)ReadByte();
        }

        /// <summary>
        /// Reads the next signed 16-bit integer from the stream.
        /// </summary>
        /// <returns>The next signed 16-bit integer read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public short ReadShort() {
            FillBuffer(2);
            return (short)(Buffer[0] << 8 | Buffer[1]);
        }

        /// <summary>
        /// Reads the next unsigned 16-bit integer from the stream.
        /// </summary>
        /// <returns>The next unsigned 16-bit integer read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public ushort ReadUnsignedShort() {
            return (ushort)ReadShort();
        }

        /// <summary>
        /// Reads the next signed 32-bit integer from the stream.
        /// </summary>
        /// <returns>The next signed 32-bit integer read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public int ReadInt() {
            FillBuffer(4);
            return Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3];
        }

        /// <summary>
        /// Reads the next unsigned 32-bit integer from the stream.
        /// </summary>
        /// <returns>The next unsigned 32-bit integer read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public uint ReadUnsignedInt() {
            return (uint)ReadInt();
        }

        /// <summary>
        /// Reads the next signed 64-bit integer from the stream.
        /// </summary>
        /// <returns>The next signed 64-bit integer read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public long ReadLong() {
            FillBuffer(8);
            uint upper = (uint)(Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3]);
            uint lower = (uint)(Buffer[4] << 24 | Buffer[5] << 16 | Buffer[6] << 8 | Buffer[7]);
            return (long)((ulong)upper << 32 | lower);
        }

        /// <summary>
        /// Reads the next unsigned 64-bit integer from the stream.
        /// </summary>
        /// <returns>The next unsigned 64-bit integer read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public ulong ReadUnsignedLong() {
            return (ulong)ReadLong();
        }

        /// <summary>
        /// Reads the next single-precision floating point number from the stream.
        /// </summary>
        /// <returns>The next single-precision floating point number read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public unsafe float ReadFloat() {
            int i = ReadInt();
            return *(float*)&i;
        }

        /// <summary>
        /// Reads the next double-precision floating point number from the stream.
        /// </summary>
        /// <returns>The next double-precision floating point number read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public unsafe double ReadDouble() {
            long l = ReadLong();
            return *(double*)&l;
        }

        /// <summary>
        /// Reads the next length-prefixed string from the stream using the <see cref="ModifiedUTF8Encoding"/> encoding.
        /// </summary>
        /// <returns>The next string read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public string ReadString() {
            int length = ReadUnsignedShort();
            byte[] bytes = ReadBytes(length);
            return Encoding.GetString(bytes);
        }

        /// <summary>
        /// Reads the next <see cref="TagType"/> from the stream.
        /// </summary>
        /// <returns>The next <see cref="TagType"/> read from the stream.</returns>
        /// <exception cref="EndOfStreamException">The end of the stream is reached.</exception>
        /// <exception cref="ObjectDisposedException">The stream is closed.</exception>
        /// <exception cref="IOException">An I/O error occurred.</exception>
        public TagType ReadTagType() {
            return (TagType)ReadByte();
        }

        private byte[] ReadBytes(int length) {
            byte[] buffer = new byte[length];
            int bytesRead = Stream.Read(buffer, 0, length);
            if (bytesRead < length) {
                throw new EndOfStreamException();
            }
            return buffer;
        }

        private void FillBuffer(int length) {
            int bytesRead = Stream.Read(Buffer, 0, length);
            if (bytesRead < length) {
                throw new EndOfStreamException();
            }
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
