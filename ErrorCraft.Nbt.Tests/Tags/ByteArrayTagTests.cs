using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void Add_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<sbyte> byteArrayTag = new ByteArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { byteArrayTag.Add(1); });
        }

        [TestMethod]
        public void Clear_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<sbyte> byteArrayTag = new ByteArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { byteArrayTag.Clear(); });
        }

        [TestMethod]
        public void Remove_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<sbyte> byteArrayTag = new ByteArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { byteArrayTag.Remove(1); });
        }

        [TestMethod]
        public void Contains_ReturnsTrue() {
            ByteArrayTag byteArrayTag = new ByteArrayTag(new sbyte[] { 1, 2, 3 });
            bool successful = byteArrayTag.Contains(1);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void Contains_ReturnsFalse() {
            ByteArrayTag byteArrayTag = new ByteArrayTag(new sbyte[] { 1, 2, 3 });
            bool successful = byteArrayTag.Contains(4);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void CopyTo_CopiesCorrectValues() {
            ByteArrayTag byteArrayTag = new ByteArrayTag(new sbyte[] { 1, 2, 3 });
            sbyte[] copyArray = new sbyte[3];

            byteArrayTag.CopyTo(copyArray, 0);
            CollectionAssert.AreEqual(new sbyte[] { 1, 2, 3 }, copyArray);
        }
    }
}
