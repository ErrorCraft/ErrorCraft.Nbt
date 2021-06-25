using ErrorCraft.Nbt.Tags;
using System;
using System.IO;
using System.Text;

namespace ErrorCraft.Nbt {
    public class BinaryWriter : IDisposable {
        private readonly Encoding Encoding = new ModifiedUTF8Encoding();
        private readonly Stream Stream;
        private readonly byte[] Buffer = new byte[sizeof(long)];

        public BinaryWriter(Stream stream) {
            Stream = stream;
        }

        public void WriteByte(sbyte value) {
            Buffer[0] = (byte)value;
            WriteBuffer(1);
        }

        public void WriteUnsignedByte(byte value) {
            WriteByte((sbyte)value);
        }

        public void WriteShort(short value) {
            Buffer[0] = (byte)(value >> 8 & 0xFF);
            Buffer[1] = (byte)(value & 0xFF);
            WriteBuffer(2);
        }

        public void WriteUnsignedShort(ushort value) {
            WriteShort((short)value);
        }

        public void WriteInt(int value) {
            for (int i = 0; i < 4; i++) {
                Buffer[i] = (byte)(value >> ((3 - i) * 8) & 0xFF);
            }
            WriteBuffer(4);
        }

        public void WriteUnsignedInt(uint value) {
            WriteInt((int)value);
        }

        public void WriteLong(long value) {
            for (int i = 0; i < 8; i++) {
                Buffer[i] = (byte)(value >> ((7 - i) * 8) & 0xFF);
            }
            WriteBuffer(8);
        }

        public void WriteUnsignedLong(ulong value) {
            WriteLong((long)value);
        }

        public unsafe void WriteFloat(float value) {
            int i = *(int*)&value;
            WriteInt(i);
        }

        public unsafe void WriteDouble(double value) {
            long l = *(long*)&value;
            WriteLong(l);
        }

        public void WriteString(string value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }
            int length = Encoding.GetByteCount(value);
            if (length > ushort.MaxValue) {
                throw new InvalidOperationException($"The number of bytes in the UTF-8 string was larger than the maximum allowed ({ushort.MaxValue})");
            }
            WriteUnsignedShort((ushort)length);
            WriteBytes(Encoding.GetBytes(value));
        }

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
