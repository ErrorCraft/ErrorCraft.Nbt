using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class BinaryWriterTests {
        [TestMethod]
        public void WriteByte_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteByte(-128);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedByte_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteUnsignedByte(128);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }

        [TestMethod]
        public void WriteShort_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteShort(-32768);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedShort_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteUnsignedShort(32768);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteInt_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteInt(-2147483648);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedInt_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteUnsignedInt(2147483648);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteLong_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteLong(-9223372036854775808L);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteUnsignedLong_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteUnsignedLong(9223372036854775808L);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteFloat_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteFloat(-1.5f);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteDouble_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteDouble(-1.5d);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void WriteString_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteString("foo");
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F }, bytes);
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
        public void WriteTagType_WritesCorrectValue() {
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            binaryWriter.WriteTagType(TagType.BYTE);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01 }, bytes);
        }
    }
}
