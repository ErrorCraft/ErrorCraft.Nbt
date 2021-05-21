using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class BinaryReaderTests {
        [TestMethod]
        public void ReadByte_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            sbyte result = binaryReader.ReadByte();
            Assert.AreEqual((sbyte)-128, result);
        }

        [TestMethod]
        public void ReadByte_ThrowsException_BecauseEndOfStreamWasReached() {
#pragma warning disable CA1825 // Avoid zero-length array allocations
            byte[] bytes = new byte[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadByte());
        }

        [TestMethod]
        public void ReadUnsignedByte_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            byte result = binaryReader.ReadUnsignedByte();
            Assert.AreEqual<byte>(128, result);
        }

        [TestMethod]
        public void ReadUnsignedByte_ThrowsException_BecauseEndOfStreamWasReached() {
#pragma warning disable CA1825 // Avoid zero-length array allocations
            byte[] bytes = new byte[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedByte());
        }

        [TestMethod]
        public void ReadShort_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            short result = binaryReader.ReadShort();
            Assert.AreEqual((short)-32768, result);
        }

        [TestMethod]
        public void ReadShort_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadShort());
        }

        [TestMethod]
        public void ReadUnsignedShort_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            ushort result = binaryReader.ReadUnsignedShort();
            Assert.AreEqual<ushort>(32768, result);
        }

        [TestMethod]
        public void ReadUnsignedShort_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedShort());
        }

        [TestMethod]
        public void ReadInt_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            int result = binaryReader.ReadInt();
            Assert.AreEqual(-2147483648, result);
        }

        [TestMethod]
        public void ReadInt_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadInt());
        }

        [TestMethod]
        public void ReadUnsignedInt_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            uint result = binaryReader.ReadUnsignedInt();
            Assert.AreEqual(2147483648, result);
        }

        [TestMethod]
        public void ReadUnsignedInt_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedInt());
        }

        [TestMethod]
        public void ReadLong_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            long result = binaryReader.ReadLong();
            Assert.AreEqual(-9223372036854775808L, result);
        }

        [TestMethod]
        public void ReadLong_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadLong());
        }

        [TestMethod]
        public void ReadUnsignedLong_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            ulong result = binaryReader.ReadUnsignedLong();
            Assert.AreEqual(9223372036854775808L, result);
        }

        [TestMethod]
        public void ReadUnsignedLong_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedLong());
        }
    }
}
