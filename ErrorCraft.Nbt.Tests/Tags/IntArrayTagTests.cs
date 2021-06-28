using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void Add_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<int> intArrayTag = new IntArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { intArrayTag.Add(1); });
        }

        [TestMethod]
        public void Clear_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<int> intArrayTag = new IntArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { intArrayTag.Clear(); });
        }

        [TestMethod]
        public void Remove_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<int> intArrayTag = new IntArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { intArrayTag.Remove(1); });
        }

        [TestMethod]
        public void Contains_ReturnsTrue() {
            IntArrayTag intArrayTag = new IntArrayTag(new int[] { 1, 2, 3 });
            bool successful = intArrayTag.Contains(1);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void Contains_ReturnsFalse() {
            IntArrayTag intArrayTag = new IntArrayTag(new int[] { 1, 2, 3 });
            bool successful = intArrayTag.Contains(4);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void CopyTo_CopiesCorrectValues() {
            IntArrayTag intArrayTag = new IntArrayTag(new int[] { 1, 2, 3 });
            int[] copyArray = new int[3];

            intArrayTag.CopyTo(copyArray, 0);
            CollectionAssert.AreEqual(new int[] { 1, 2, 3 }, copyArray);
        }
    }
}
