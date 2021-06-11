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
    }
}
