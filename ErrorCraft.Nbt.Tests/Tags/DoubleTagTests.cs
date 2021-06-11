using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests.Tags {
    [TestClass]
    public class DoubleTagTests {
        [TestMethod]
        public void GetTagType_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag();
            TagType tagType = doubleTag.GetTagType();
            Assert.AreEqual(TagType.DOUBLE, tagType);
        }

        [TestMethod]
        public void GetAsByte_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag(-1.5d);
            sbyte result = doubleTag.GetAsByte();
            Assert.AreEqual<sbyte>(-1, result);
        }

        [TestMethod]
        public void GetAsShort_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag(-1.5d);
            short result = doubleTag.GetAsShort();
            Assert.AreEqual<short>(-1, result);
        }

        [TestMethod]
        public void GetAsInt_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag(-1.5d);
            int result = doubleTag.GetAsInt();
            Assert.AreEqual(-1, result);
        }

        [TestMethod]
        public void GetAsLong_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag(-1.5d);
            long result = doubleTag.GetAsLong();
            Assert.AreEqual(-1L, result);
        }

        [TestMethod]
        public void GetAsFloat_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag(-1.5d);
            float result = doubleTag.GetAsFloat();
            Assert.AreEqual(-1.5f, result);
        }

        [TestMethod]
        public void GetAsDouble_ReturnsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag(-1.5d);
            double result = doubleTag.GetAsDouble();
            Assert.AreEqual(-1.5d, result);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            DoubleTag doubleTag = new DoubleTag();
            byte[] bytes = new byte[] { 0xBF, 0xF8, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            doubleTag.Read(binaryReader);
            Assert.AreEqual(-1.5d, doubleTag.GetAsDouble());
        }
    }
}
