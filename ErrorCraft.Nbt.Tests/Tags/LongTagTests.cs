using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

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

        [TestMethod]
        public void GetAsFloat_ReturnsCorrectValue() {
            LongTag longTag = new LongTag(0x3322110011223344L);
            float result = longTag.GetAsFloat();
            Assert.AreEqual(3684526137127613252.0f, result);
        }

        [TestMethod]
        public void GetAsDouble_ReturnsCorrectValue() {
            LongTag longTag = new LongTag(0x3322110011223344L);
            double result = longTag.GetAsDouble();
            Assert.AreEqual(3684526137127613252.0d, result);
        }

        [TestMethod]
        public void Read_ReadsCorrectValue() {
            LongTag longTag = new LongTag();
            byte[] bytes = new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using BinaryReader binaryReader = new BinaryReader(memoryStream);

            longTag.Read(binaryReader);
            Assert.AreEqual(-9223372036854775808L, longTag.GetAsLong());
        }

        [TestMethod]
        public void Write_WritesCorrectValue() {
            LongTag longTag = new LongTag(-9223372036854775808L);
            using MemoryStream memoryStream = new MemoryStream();
            using BinaryWriter binaryWriter = new BinaryWriter(memoryStream);

            longTag.Write(binaryWriter);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x80, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 }, bytes);
        }

        [TestMethod]
        public void AreEqual_ReturnsTrue() {
            LongTag longTag = new LongTag(1L);
            LongTag longTag2 = new LongTag(1L);
            bool successful = longTag.Equals(longTag2);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse() {
            LongTag longTag = new LongTag(1L);
            LongTag longTag2 = new LongTag(2L);
            bool successful = longTag.Equals(longTag2);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_ReturnsFalse_BecauseValueIsNull() {
            LongTag longTag = new LongTag(1L);
            LongTag longTag2 = null;
            bool successful = longTag.Equals(longTag2);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsTrue() {
            LongTag longTag = new LongTag(1L);
            INumberTag numberTag = new LongTag(1L);
            bool successful = longTag.Equals(numberTag);
            Assert.IsTrue(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsFalse() {
            LongTag longTag = new LongTag(1L);
            INumberTag numberTag = new LongTag(2L);
            bool successful = longTag.Equals(numberTag);
            Assert.IsFalse(successful);
        }

        [TestMethod]
        public void AreEqual_WithINumberTag_ReturnsFalse_BecauseValueIsNull() {
            LongTag longTag = new LongTag(1L);
            INumberTag numberTag = null;
            bool successful = longTag.Equals(numberTag);
            Assert.IsFalse(successful);
        }
    }
}
