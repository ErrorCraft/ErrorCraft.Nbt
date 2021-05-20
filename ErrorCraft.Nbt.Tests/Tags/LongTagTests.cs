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
    }
}
