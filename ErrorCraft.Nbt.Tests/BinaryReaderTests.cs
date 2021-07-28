using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class BinaryReaderTests {
        [TestMethod]
        public void ReadByte_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            sbyte result = binaryReader.ReadByte();
            Assert.AreEqual<sbyte>(-128, result);
        }

        [TestMethod]
        public void ReadByte_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            sbyte result = binaryReader.ReadByte();
            Assert.AreEqual<sbyte>(-128, result);
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
        public void ReadUnsignedByte_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            byte result = binaryReader.ReadUnsignedByte();
            Assert.AreEqual<byte>(128, result);
        }

        [TestMethod]
        public void ReadUnsignedByte_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

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
        public void ReadShort_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            short result = binaryReader.ReadShort();
            Assert.AreEqual<short>(-32768, result);
        }

        [TestMethod]
        public void ReadShort_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            short result = binaryReader.ReadShort();
            Assert.AreEqual<short>(-32768, result);
        }

        [TestMethod]
        public void ReadShort_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadShort());
        }

        [TestMethod]
        public void ReadUnsignedShort_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            ushort result = binaryReader.ReadUnsignedShort();
            Assert.AreEqual<ushort>(32768, result);
        }

        [TestMethod]
        public void ReadUnsignedShort_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

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
        public void ReadInt_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            int result = binaryReader.ReadInt();
            Assert.AreEqual(-2147483648, result);
        }

        [TestMethod]
        public void ReadInt_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

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
        public void ReadUnsignedInt_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            uint result = binaryReader.ReadUnsignedInt();
            Assert.AreEqual(2147483648, result);
        }

        [TestMethod]
        public void ReadUnsignedInt_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

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
        public void ReadLong_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            long result = binaryReader.ReadLong();
            Assert.AreEqual(-9223372036854775808L, result);
        }

        [TestMethod]
        public void ReadLong_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

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
        public void ReadUnsignedLong_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            ulong result = binaryReader.ReadUnsignedLong();
            Assert.AreEqual(9223372036854775808L, result);
        }

        [TestMethod]
        public void ReadUnsignedLong_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

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

        [TestMethod]
        public void ReadFloat_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0xBF, 0xC0, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            float result = binaryReader.ReadFloat();
            Assert.AreEqual(-1.5f, result);
        }

        [TestMethod]
        public void ReadFloat_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x00, 0xC0, 0xBF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            float result = binaryReader.ReadFloat();
            Assert.AreEqual(-1.5f, result);
        }

        [TestMethod]
        public void ReadFloat_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0xBF, 0xC0, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadFloat());
        }

        [TestMethod]
        public void ReadDouble_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            double result = binaryReader.ReadDouble();
            Assert.AreEqual(-1.5d, result);
        }

        [TestMethod]
        public void ReadDouble_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF8, 0xBF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            double result = binaryReader.ReadDouble();
            Assert.AreEqual(-1.5d, result);
        }

        [TestMethod]
        public void ReadDouble_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadDouble());
        }

        [TestMethod]
        public void ReadString_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x00, 0x05, 0x66, 0xC3, 0xB6, 0xC3, 0xB6 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            string result = binaryReader.ReadString();
            Assert.AreEqual("föö", result);
        }

        [TestMethod]
        public void ReadString_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x05, 0x00, 0x66, 0xC3, 0xB6, 0xC3, 0xB6 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            string result = binaryReader.ReadString();
            Assert.AreEqual("föö", result);
        }

        [TestMethod]
        public void ReadString_ThrowsException_BecauseEndOfStreamWasReached() {
            byte[] bytes = new byte[] { 0x00, 0x03 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadUnsignedLong());
        }

        [TestMethod]
        public void ReadTagType_WithBigEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x01 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, true);

            TagType result = binaryReader.ReadTagType();
            Assert.AreEqual(TagType.BYTE, result);
        }

        [TestMethod]
        public void ReadTagType_WithLittleEndian_ReadsCorrectValue() {
            byte[] bytes = new byte[] { 0x01 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream, false);

            TagType result = binaryReader.ReadTagType();
            Assert.AreEqual(TagType.BYTE, result);
        }

        [TestMethod]
        public void ReadTagType_ThrowsException_BecauseEndOfStreamWasReached() {
#pragma warning disable CA1825 // Avoid zero-length array allocations
            byte[] bytes = new byte[0];
#pragma warning restore CA1825 // Avoid zero-length array allocations
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<EndOfStreamException>(() => binaryReader.ReadTagType());
        }
    }
}
