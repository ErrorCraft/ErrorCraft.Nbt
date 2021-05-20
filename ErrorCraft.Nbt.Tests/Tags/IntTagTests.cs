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
    }
}
