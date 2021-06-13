using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class ByteTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag();
            TagType tagType = byteTag.GetTagType();
            Assert.AreEqual(TagType.BYTE, tagType);
        }

        [TestMethod]
        public void GetAsByte_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            sbyte result = byteTag.GetAsByte();
            Assert.AreEqual<sbyte>(0x44, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            short result = byteTag.GetAsShort();
            Assert.AreEqual<short>(0x44, result);
        }

        [TestMethod]
        public void GetAsInt_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            int result = byteTag.GetAsInt();
            Assert.AreEqual(0x44, result);
        }

        [TestMethod]
        public void GetAsLong_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            long result = byteTag.GetAsLong();
            Assert.AreEqual(0x44L, result);
        }

        [TestMethod]
        public void GetAsFloat_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            float result = byteTag.GetAsFloat();
            Assert.AreEqual(68.0f, result);
        }

        [TestMethod]
        public void GetAsDouble_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            double result = byteTag.GetAsDouble();
            Assert.AreEqual(68.0d, result);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            ByteTag byteTag = new ByteTag();
            byte[] bytes = new byte[] { 0x80 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            byteTag.Read(binaryReader);
            Assert.AreEqual<sbyte>(-128, byteTag.GetAsByte());
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            ByteTag byteTag = new ByteTag(-128);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            byteTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80 }, bytes);
        }
    }
}
