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
    }
}
