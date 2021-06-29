using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class StringTagTests {
        [TestMethod]
        public void Constructor_CreatesCorrectObject() {
            StringTag stringTag = new StringTag("foo");
            Assert.AreEqual("foo", stringTag.GetString());
        }

        [TestMethod]
        public void Constructor_ThrowsException_BecauseStringIsNull() {
            Assert.ThrowsException<ArgumentNullException>(() => new StringTag(null));
        }

        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            StringTag stringTag = new StringTag();
            TagType tagType = stringTag.GetTagType();
            Assert.AreEqual(TagType.STRING, tagType);
        }

        [TestMethod]
        public void GetString_ReturnsCorrectValue() {
            StringTag stringTag = new StringTag("foo");
            string result = stringTag.GetString();
            Assert.AreEqual("foo", result);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            StringTag stringTag = new StringTag();
            byte[] bytes = new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            stringTag.Read(binaryReader);
            Assert.AreEqual("foo", stringTag.GetString());
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            StringTag stringTag = new StringTag("foo");
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            stringTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x00, 0x03, 0x66, 0x6F, 0x6F }, bytes);
        }

        [TestMethod]
        public void AreEqual_ReturnsTrue() {
            StringTag stringTag = new StringTag("foo");
            StringTag stringTag2 = new StringTag("foo");
            bool successful = stringTag.Equals(stringTag2);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse() {
            StringTag stringTag = new StringTag("foo");
            StringTag stringTag2 = new StringTag("bar");
            bool successful = stringTag.Equals(stringTag2);
            Assert.IsFalse(successful);
        }
    }
}
