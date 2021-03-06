using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class FloatTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag();
            TagType tagType = floatTag.GetTagType();
            Assert.AreEqual(TagType.FLOAT, tagType);
        }

        [TestMethod]
        public void GetAsByte_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            sbyte result = floatTag.GetAsByte();
            Assert.AreEqual<sbyte>(-1, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            short result = floatTag.GetAsShort();
            Assert.AreEqual<short>(-1, result);
        }

        [TestMethod]
        public void GetAsInt_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            int result = floatTag.GetAsInt();
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void GetAsLong_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            long result = floatTag.GetAsLong();
            Assert.AreEqual(-1L, result);
        }

        [TestMethod]
        public void GetAsFloat_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            float result = floatTag.GetAsFloat();
            Assert.AreEqual(-1.5f, result);
        }

        [TestMethod]
        public void GetAsDouble_ReturnsCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            double result = floatTag.GetAsDouble();
            Assert.AreEqual(-1.5d, result);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            FloatTag floatTag = new FloatTag();
            byte[] bytes = new byte[] { 0xBF, 0xC0, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            floatTag.Read(binaryReader);
            Assert.AreEqual(-1.5f, floatTag.GetAsFloat());
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            FloatTag floatTag = new FloatTag(-1.5f);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            floatTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0xBF, 0xC0, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void AreEqual_ReturnsTrue() {
            FloatTag floatTag = new FloatTag(1.0f);
            FloatTag floatTag2 = new FloatTag(1.0f);
            bool successful = floatTag.Equals(floatTag2);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse() {
            FloatTag floatTag = new FloatTag(1.0f);
            FloatTag floatTag2 = new FloatTag(2.0f);
            bool successful = floatTag.Equals(floatTag2);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse_BecauseValueIsNull() {
            FloatTag floatTag = new FloatTag(1.0f);
            FloatTag floatTag2 = null;
            bool successful = floatTag.Equals(floatTag2);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsTrue() {
            FloatTag floatTag = new FloatTag(1.0f);
            INumberTag numberTag = new FloatTag(1.0f);
            bool successful = floatTag.Equals(numberTag);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsFalse() {
            FloatTag floatTag = new FloatTag(1.0f);
            INumberTag numberTag = new FloatTag(2.0f);
            bool successful = floatTag.Equals(numberTag);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsFalse_BecauseValueIsNull() {
            FloatTag floatTag = new FloatTag(1.0f);
            INumberTag numberTag = null;
            bool successful = floatTag.Equals(numberTag);
            Assert.IsFalse(successful);
        }
    }
}
