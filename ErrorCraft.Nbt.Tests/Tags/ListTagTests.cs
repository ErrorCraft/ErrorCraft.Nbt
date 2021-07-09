using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class ListTagTests {
        [TestMethod]
        public void Get_ReturnsCorrectValue() {
            ListTag listTag = new ListTag() {
                new ByteTag(1),
                new ByteTag(2),
                new ByteTag(3)
            };
            ITag result = listTag[0];
            Assert.AreEqual(new ByteTag(1), result);
        }

        [TestMethod]
        public void Set_OverwritesCorrectValue() {
            ListTag listTag = new ListTag() {
                new ByteTag(1),
                new ByteTag(2),
                new ByteTag(3)
            };
            listTag[0] = new ByteTag(2);
            Assert.AreEqual(new ByteTag(2), listTag[0]);
        }

        [TestMethod]
        public void Set_ThrowsException_BecauseTagTypeIsInvalid() {
            ListTag listTag = new ListTag() {
                new ByteTag(1),
                new ByteTag(2),
                new ByteTag(3)
            };
            Assert.ThrowsException<ArgumentException>(() => listTag[0] = new IntTag(2));
        }

        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            ListTag listTag = new ListTag();
            TagType tagType = listTag.GetTagType();
            Assert.AreEqual(TagType.LIST, tagType);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            ListTag listTag = new ListTag();
            byte[] bytes = new byte[] { 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            listTag.Read(binaryReader);
            Assert.AreEqual(4, listTag.Count);
        }

        [TestMethod]
        public void Read_ThrowsException_BecauseListHasItemsButNoTagType() {
            ListTag listTag = new ListTag();
            byte[] bytes = new byte[] { 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            Assert.ThrowsException<ArgumentException>(() => listTag.Read(binaryReader));
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            ListTag listTag = new ListTag() {
                new ByteTag(0),
                new ByteTag(127),
                new ByteTag(-128),
                new ByteTag(-1)
            };
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            listTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x00, 0x00, 0x04, 0x00, 0x7F, 0x80, 0xFF }, bytes);
        }

        [TestMethod]
        public void Add_AddsItem() {
#pragma warning disable IDE0028 // Simplify collection initialization
            ListTag listTag = new ListTag();
#pragma warning restore IDE0028 // Simplify collection initialization
            listTag.Add(new ByteTag(1));
            Assert.AreEqual(1, listTag.Count);
        }

        [TestMethod]
        public void Add_ThrowsException_BecauseTagTypeIsInvalid() {
            ListTag listTag = new ListTag {
                new ByteTag(1)
            };
            Assert.ThrowsException<ArgumentException>(() => listTag.Add(new IntTag(1)));
        }

        [TestMethod]
        public void Clear_RemovesAllItems() {
            ListTag listTag = new ListTag() {
                new ByteTag(1),
                new ByteTag(2)
            };
            listTag.Clear();
            Assert.AreEqual(0, listTag.Count);
        }

        [TestMethod]
        public void Clear_ResetsElementTagType() {
            ListTag listTag = new ListTag() {
                new ByteTag(1),
                new ByteTag(2)
            };
            listTag.Clear();
            Assert.AreEqual(TagType.END, listTag.GetElementTagType());
        }

        [TestMethod]
        public void Remove_ReturnsTrue() {
            ByteTag byteTag = new ByteTag(1);
            ListTag listTag = new ListTag {
                byteTag
            };
            bool successful = listTag.Remove(byteTag);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void Remove_ResetsElementTagType_BecauseNewListWasEmpty() {
            ByteTag byteTag = new ByteTag(1);
            ListTag listTag = new ListTag {
                byteTag
            };
            listTag.Remove(byteTag);
            Assert.AreEqual(TagType.END, listTag.GetElementTagType());
        }

        [TestMethod]
        public void Remove_ReturnsFalse() {
            ByteTag byteTag = new ByteTag(1);
            ListTag listTag = new ListTag();
            bool successful = listTag.Remove(byteTag);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void Contains_ReturnsTrue() {
            ByteTag byteTag = new ByteTag(1);
            ListTag listTag = new ListTag {
                byteTag
            };
            bool successful = listTag.Contains(byteTag);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void Contains_ReturnsFalse() {
            ByteTag byteTag = new ByteTag(1);
            ListTag listTag = new ListTag();
            bool successful = listTag.Contains(byteTag);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void CopyTo_CopiesCorrectValues() {
            ListTag listTag = new ListTag() {
                new ByteTag(1),
                new ByteTag(2),
                new ByteTag(3)
            };
            ITag[] copyArray = new ITag[3];

            listTag.CopyTo(copyArray, 0);
            CollectionAssert.AreEqual(new ITag[] { new ByteTag(1), new ByteTag(2), new ByteTag(3) }, copyArray);
        }

        [TestMethod]
        public void GetElementTagType_ReturnsCorrectValue() {
            ListTag listTag = new ListTag() {
                new ByteTag(1)
            };
            TagType elementTagType = listTag.GetElementTagType();
            Assert.AreEqual(TagType.BYTE, elementTagType);
        }
    }
}
