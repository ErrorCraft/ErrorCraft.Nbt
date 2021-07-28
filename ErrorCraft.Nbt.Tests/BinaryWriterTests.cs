using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class BinaryWriterTests {
        [TestMethod]
        public void WriteByte_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteByte(-128);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteByte_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteByte(-128);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedByte_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteUnsignedByte(128);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedByte_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteUnsignedByte(128);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteShort_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteShort(-32768);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteShort_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteShort(-32768);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedShort_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteUnsignedShort(32768);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedShort_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteUnsignedShort(32768);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteInt_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteInt(-2147483648);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteInt_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteInt(-2147483648);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedInt_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteUnsignedInt(2147483648);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedInt_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteUnsignedInt(2147483648);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteLong_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteLong(-9223372036854775808L);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteLong_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteLong(-9223372036854775808L);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedLong_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteUnsignedLong(9223372036854775808L);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedLong_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteUnsignedLong(9223372036854775808L);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteFloat_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteFloat(-1.5f);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteFloat_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteFloat(-1.5f);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0xC0, 0xBF }, bytes);
        }

        [TestMethod]
        public void WriteDouble_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteDouble(-1.5d);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteDouble_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteDouble(-1.5d);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xF8, 0xBF }, bytes);
        }

        [TestMethod]
        public void WriteString_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteString("foo");
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F }, bytes);
        }

        [TestMethod]
        public void WriteString_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteString("foo");
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x03, 0x00, 0x66, 0x6F, 0x6F }, bytes);
        }

        [TestMethod]
        public void WriteString_ThrowsException_BecauseStringWasNull() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            Assert.ThrowsException<ArgumentNullException>(() => binaryWriter.WriteString(null));
        }

        [TestMethod]
        public void WriteString_ThrowsException_BecauseStringIsTooLong() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            Assert.ThrowsException<InvalidOperationException>(() => binaryWriter.WriteString(new string('a', 65536)));
        }

        [TestMethod]
        public void WriteTagType_WithBigEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, true);

            binaryWriter.WriteTagType(TagType.BYTE);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01 }, bytes);
        }

        [TestMethod]
        public void WriteTagType_WithLittleEndian_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream, false);

            binaryWriter.WriteTagType(TagType.BYTE);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01 }, bytes);
        }
    }
}
