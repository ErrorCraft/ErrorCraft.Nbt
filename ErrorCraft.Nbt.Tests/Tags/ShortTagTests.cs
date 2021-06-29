using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        [TestMethod]
        public void GetAsFloat_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag(0x3344);
            float result = shortTag.GetAsFloat();
            Assert.AreEqual(13124.0f, result);
        }

        [TestMethod]
        public void GetAsDouble_ReturnsCorrectValue() {
            ShortTag shortTag = new ShortTag(0x3344);
            double result = shortTag.GetAsLong();
            Assert.AreEqual(13124.0d, result);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            ShortTag shortTag = new ShortTag();
            byte[] bytes = new byte[] { 0x80, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            shortTag.Read(binaryReader);
            Assert.AreEqual<short>(-32768, shortTag.GetAsShort());
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            ShortTag shortTag = new ShortTag(-32768);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            shortTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00 }, bytes);
        }

        [TestMethod]
        public void AreEqual_ReturnsTrue() {
            ShortTag shortTag = new ShortTag(1);
            ShortTag shortTag2 = new ShortTag(1);
            bool successful = shortTag.Equals(shortTag2);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse() {
            ShortTag shortTag = new ShortTag(1);
            ShortTag shortTag2 = new ShortTag(2);
            bool successful = shortTag.Equals(shortTag2);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse_BecauseValueIsNull() {
            ShortTag shortTag = new ShortTag(1);
            ShortTag shortTag2 = null;
            bool successful = shortTag.Equals(shortTag2);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsTrue() {
            ShortTag shortTag = new ShortTag(1);
            INumberTag numberTag = new ShortTag(1);
            bool successful = shortTag.Equals(numberTag);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsFalse() {
            ShortTag shortTag = new ShortTag(1);
            INumberTag numberTag = new ShortTag(2);
            bool successful = shortTag.Equals(numberTag);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsFalse_BecauseValueIsNull() {
            ShortTag shortTag = new ShortTag(1);
            INumberTag numberTag = null;
            bool successful = shortTag.Equals(numberTag);
            Assert.IsFalse(successful);
        }
    }
}
