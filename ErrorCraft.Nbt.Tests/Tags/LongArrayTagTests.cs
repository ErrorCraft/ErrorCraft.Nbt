using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class LongArrayTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            LongArrayTag longArrayTag = new LongArrayTag();
            TagType tagType = longArrayTag.GetTagType();
            Assert.AreEqual(TagType.LONG_ARRAY, tagType);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            LongArrayTag longArrayTag = new LongArrayTag();
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            longArrayTag.Read(binaryReader);
            Assert.AreEqual(4, longArrayTag.Count);
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            LongArrayTag longArrayTag = new LongArrayTag(new long[] { 0x0, 9223372036854775807, -9223372036854775808, -1 });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            longArrayTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x7F, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF }, bytes);
        }
    }
}
