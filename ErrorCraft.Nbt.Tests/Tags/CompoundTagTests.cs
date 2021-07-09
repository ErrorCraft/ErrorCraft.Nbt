using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class CompoundTagTests {
        [TestMethod]
        public void Get_ReturnsCorrectValue() {
            CompoundTag compoundTag = new CompoundTag(new Dictionary<string, ITag>() { { "foo", new ByteTag(1) }, { "bar", new ByteTag(2) } });
            ITag result = compoundTag["foo"];
            Assert.AreEqual(new ByteTag(1), result);
        }

        [TestMethod]
        public void Set_OverwritesCorrectValue() {
            CompoundTag compoundTag = new CompoundTag(new Dictionary<string, ITag>() { { "foo", new ByteTag(1) }, { "bar", new ByteTag(2) } });
            compoundTag["foo"] = new ByteTag(3);
            Assert.AreEqual(new ByteTag(3), compoundTag["foo"]);
        }

        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            CompoundTag compoundTag = new CompoundTag();
            TagType tagType = compoundTag.GetTagType();
            Assert.AreEqual(TagType.COMPOUND, tagType);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            CompoundTag compoundTag = new CompoundTag();
            byte[] bytes = new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x7F, 0x01, 0x00, 0x03, 0x62, 0x61, 0x72, 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            compoundTag.Read(binaryReader);
            Assert.AreEqual(2, compoundTag.Count);
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            CompoundTag compoundTag = new CompoundTag(new Dictionary<string, ITag>() { { "foo", new ByteTag(127) }, { "bar", new ByteTag(-128) } });
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            compoundTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x7F, 0x01, 0x00, 0x03, 0x62, 0x61, 0x72, 0x80, 0x00 }, bytes);
        }
    }
}
