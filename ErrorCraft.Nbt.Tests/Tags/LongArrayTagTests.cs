using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class LongArrayTagTests {
        [TestMethod]
        public void Constructor_CreatesCorrectObject() {
            LongArrayTag longArrayTag = new LongArrayTag(new long[] { 1L, 2L, 3L });
            Assert.AreEqual(3, longArrayTag.Count);
        }

        [TestMethod]
        public void Constructor_ThrowsException_BecauseArrayIsNull() {
            Assert.ThrowsException<ArgumentNullException>(() => new LongArrayTag(null));
        }

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

        [TestMethod]
        public void Add_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<long> longArrayTag = new LongArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { longArrayTag.Add(1L); });
        }

        [TestMethod]
        public void Clear_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<long> longArrayTag = new LongArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { longArrayTag.Clear(); });
        }

        [TestMethod]
        public void Remove_ThrowsException_BecauseArrayIsFixedSize() {
            ICollectionTag<long> longArrayTag = new LongArrayTag();
            Assert.ThrowsException<NotSupportedException>(() => { longArrayTag.Remove(1L); });
        }

        [TestMethod]
        public void Contains_ReturnsTrue() {
            LongArrayTag longArrayTag = new LongArrayTag(new long[] { 1L, 2L, 3L });
            bool successful = longArrayTag.Contains(1L);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void Contains_ReturnsFalse() {
            LongArrayTag longArrayTag = new LongArrayTag(new long[] { 1L, 2L, 3L });
            bool successful = longArrayTag.Contains(4L);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void CopyTo_CopiesCorrectValues() {
            LongArrayTag longArrayTag = new LongArrayTag(new long[] { 1L, 2L, 3L });
            long[] copyArray = new long[3];

            longArrayTag.CopyTo(copyArray, 0);
            CollectionAssert.AreEqual(new long[] { 1L, 2L, 3L }, copyArray);
        }
    }
}
