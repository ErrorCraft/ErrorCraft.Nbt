using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class IntArrayTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            IntArrayTag intArrayTag = new IntArrayTag();
            TagType tagType = intArrayTag.GetTagType();
            Assert.AreEqual(TagType.INT_ARRAY, tagType);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            IntArrayTag intArrayTag = new IntArrayTag();
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            intArrayTag.Read(binaryReader);
            Assert.AreEqual(4, intArrayTag.Count);
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            IntArrayTag intArrayTag = new IntArrayTag(new int[] { 0, 2147483647, -2147483648, -1 });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            intArrayTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF }, bytes);
        }
    }
}
