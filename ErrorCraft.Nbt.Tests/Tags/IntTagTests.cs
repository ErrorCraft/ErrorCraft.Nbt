using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class IntTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            IntTag intTag = new IntTag();
            TagType tagType = intTag.GetTagType();
            Assert.AreEqual(TagType.INT, tagType);
        }

        [TestMethod]
        public void GetAsByte_ReturnsCorrectValue() {
            IntTag intTag = new IntTag(0x11223344);
            sbyte result = intTag.GetAsByte();
            Assert.AreEqual<sbyte>(0x44, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            IntTag intTag = new IntTag(0x11223344);
            short result = intTag.GetAsShort();
            Assert.AreEqual<short>(0x3344, result);
        }

        [TestMethod]
        public void GetAsInt_ReturnsCorrectValue() {
            IntTag intTag = new IntTag(0x11223344);
            int result = intTag.GetAsInt();
            Assert.AreEqual(0x11223344, result);
        }

        [TestMethod]
        public void GetAsLong_ReturnsCorrectValue() {
            IntTag intTag = new IntTag(0x11223344);
            long result = intTag.GetAsLong();
            Assert.AreEqual(0x11223344L, result);
        }
    }
}
