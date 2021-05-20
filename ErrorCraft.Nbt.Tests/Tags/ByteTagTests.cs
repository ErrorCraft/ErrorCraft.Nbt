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
    }
}
