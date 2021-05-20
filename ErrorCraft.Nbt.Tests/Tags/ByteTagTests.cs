using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.AreEqual((sbyte)0x44, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            ByteTag byteTag = new ByteTag(0x44);
            short result = byteTag.GetAsShort();
            Assert.AreEqual((short)0x44, result);
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
    }
}
