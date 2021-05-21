using System;
using System.IO;

namespace ErrorCraft.Nbt {
    public class BinaryReader : IDisposable {
        private readonly Stream Stream;
        private readonly byte[] Buffer = new byte[sizeof(long)];

        public BinaryReader(Stream stream) {
            Stream = stream;
        }

        public sbyte ReadByte() {
            FillBuffer(1);
            return (sbyte)Buffer[0];
        }

        public byte ReadUnsignedByte() {
            return (byte)ReadByte();
        }

        public short ReadShort() {
            FillBuffer(2);
            return (short)(Buffer[0] << 8 | Buffer[1]);
        }

        public ushort ReadUnsignedShort() {
            return (ushort)ReadShort();
        }

        public int ReadInt() {
            FillBuffer(4);
            return Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3];
        }

        public uint ReadUnsignedInt() {
            return (uint)ReadInt();
        }

        public long ReadLong() {
            FillBuffer(8);
            uint upper = (uint)(Buffer[0] << 24 | Buffer[1] << 16 | Buffer[2] << 8 | Buffer[3]);
            uint lower = (uint)(Buffer[4] << 24 | Buffer[5] << 16 | Buffer[6] << 8 | Buffer[7]);
            return (long)((ulong)upper << 32 | lower);
        }

        public ulong ReadUnsignedLong() {
            return (ulong)ReadLong();
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
