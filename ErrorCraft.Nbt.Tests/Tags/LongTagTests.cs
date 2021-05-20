using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class LongTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            LongTag longTag = new LongTag();
            TagType tagType = longTag.GetTagType();
            Assert.AreEqual(TagType.LONG, tagType);
        }

        [TestMethod]
        public void GetAsByte_ReturnsCorrectValue() {
            LongTag longTag = new LongTag(0x3322110011223344L);
            sbyte result = longTag.GetAsByte();
            Assert.AreEqual<sbyte>(0x44, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            LongTag longTag = new LongTag(0x3322110011223344L);
            short result = longTag.GetAsShort();
            Assert.AreEqual<short>(0x3344, result);
        }

        [TestMethod]
        public void GetAsInt_ReturnsCorrectValue() {
            LongTag longTag = new LongTag(0x3322110011223344L);
            int result = longTag.GetAsInt();
            Assert.AreEqual(0x11223344, result);
        }

        [TestMethod]
        public void GetAsLong_ReturnsCorrectValue() {
            LongTag longTag = new LongTag(0x3322110011223344L);
            long result = longTag.GetAsLong();
            Assert.AreEqual(0x3322110011223344L, result);
        }
    }
}
