using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class ShortTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag();
            TagType tagType = shortTag.GetTagType();
            Assert.AreEqual(TagType.SHORT, tagType);
        }

        [TestMethod]
        public void GetAsByte_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag(0x3344);
            sbyte result = shortTag.GetAsByte();
            Assert.AreEqual<sbyte>(0x44, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag(0x3344);
            short result = shortTag.GetAsShort();
            Assert.AreEqual<short>(0x3344, result);
        }

        [TestMethod]
        public void GetAsInt_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag(0x3344);
            int result = shortTag.GetAsInt();
            Assert.AreEqual(0x3344, result);
        }

        [TestMethod]
        public void GetAsLong_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag(0x3344);
            long result = shortTag.GetAsLong();
            Assert.AreEqual(0x3344L, result);
        }
    }
}
