using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class ByteArrayTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            ByteArrayTag byteArrayTag = new ByteArrayTag();
            TagType tagType = byteArrayTag.GetTagType();
            Assert.AreEqual(TagType.BYTE_ARRAY, tagType);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            ByteArrayTag byteArrayTag = new ByteArrayTag();
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            byteArrayTag.Read(binaryReader);
            Assert.AreEqual(4, byteArrayTag.Count);
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            ByteArrayTag byteArrayTag = new ByteArrayTag(new sbyte[] { 0, 127, -128, -1 });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            byteArrayTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF }, bytes);
        }
    }
}
