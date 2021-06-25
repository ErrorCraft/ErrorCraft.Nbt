using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class ModifiedUTF8EncodingTests {
        [TestMethod]
        public void GetByteCount_ReturnsCorrectValue() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int byteCount = encoding.GetByteCount(new char[] { '\u0020' }, 0, 1);
            Assert.AreEqual(1, byteCount);
        }

        [TestMethod]
        public void GetByteCount_ReturnsCorrectValue_WithNullCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int byteCount = encoding.GetByteCount(new char[] { '\u0000' }, 0, 1);
            Assert.AreEqual(2, byteCount);
        }

        [TestMethod]
        public void GetByteCount_ReturnsCorrectValue_With8BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int byteCount = encoding.GetByteCount(new char[] { '\u0080' }, 0, 1);
            Assert.AreEqual(2, byteCount);
        }

        [TestMethod]
        public void GetByteCount_ReturnsCorrectValue_With16BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int byteCount = encoding.GetByteCount(new char[] { '\u0800' }, 0, 1);
            Assert.AreEqual(3, byteCount);
        }

        [TestMethod]
        public void GetByteCount_ThrowsException_BecauseCharArrayIsNull() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentNullException>(() => encoding.GetByteCount(null as char[], 0, 1));
        }

        [TestMethod]
        public void GetByteCount_ThrowsException_BecauseIndexIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetByteCount(new char[] { '\u0020' }, -1, 1));
        }

        [TestMethod]
        public void GetByteCount_ThrowsException_BecauseCountIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetByteCount(new char[] { '\u0020' }, 0, -1));
        }

        [TestMethod]
        public void GetByteCount_ThrowsException_BecauseCountIsTooLarge() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetByteCount(new char[] { '\u0020' }, 0, 100));
        }

        [TestMethod]
        public void GetBytes_ReturnsCorrectValue() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            byte[] bytes = new byte[1];
            encoding.GetBytes(new char[] { '\u0020' }, 0, 1, bytes, 0);
            CollectionAssert.AreEqual(new byte[] { 0x20 }, bytes);
        }

        [TestMethod]
        public void GetBytes_ReturnsCorrectValue_WithNullCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            byte[] bytes = new byte[2];
            encoding.GetBytes(new char[] { '\u0000' }, 0, 1, bytes, 0);
            CollectionAssert.AreEqual(new byte[] { 0xC0, 0x80 }, bytes);
        }

        [TestMethod]
        public void GetBytes_ReturnsCorrectValue_With8BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            byte[] bytes = new byte[2];
            encoding.GetBytes(new char[] { '\u0080' }, 0, 1, bytes, 0);
            CollectionAssert.AreEqual(new byte[] { 0xC2, 0x80 }, bytes);
        }

        [TestMethod]
        public void GetBytes_ReturnsCorrectValue_With16BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            byte[] bytes = new byte[3];
            encoding.GetBytes(new char[] { '\u0800' }, 0, 1, bytes, 0);
            CollectionAssert.AreEqual(new byte[] { 0xE0, 0xA0, 0x80 }, bytes);
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseCharArrayIsNull() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentNullException>(() => encoding.GetBytes(null as char[], 0, 1, new byte[3], 0));
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseByteArrayIsNull() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentNullException>(() => encoding.GetBytes(new char[] { '\u0800' }, 0, 1, null, 0));
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseCharIndexIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetBytes(new char[] { '\u0800' }, -1, 1, new byte[3], 0));
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseCharCountIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetBytes(new char[] { '\u0800' }, 0, -1, new byte[3], 0));
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseCharCountIsTooLarge() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetBytes(new char[] { '\u0800' }, 0, 100, new byte[3], 0));
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseByteIndexIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetBytes(new char[] { '\u0800' }, 0, 1, new byte[3], -1));
        }

        [TestMethod]
        public void GetBytes_ThrowsException_BecauseNumberOfBytesDoesNotFitInArray() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
#pragma warning disable CA1825 // Avoid zero-length array allocations
            Assert.ThrowsException<ArgumentException>(() => encoding.GetBytes(new char[] { '\u0800' }, 0, 1, new byte[0], 0));
#pragma warning restore CA1825 // Avoid zero-length array allocations
        }

        [TestMethod]
        public void GetCharCount_ReturnsCorrectValue() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int charCount = encoding.GetCharCount(new byte[] { 0x20 }, 0, 1);
            Assert.AreEqual(1, charCount);
        }

        [TestMethod]
        public void GetCharCount_ReturnsCorrectValue_WithNullCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int charCount = encoding.GetCharCount(new byte[] { 0xC0, 0x80 }, 0, 2);
            Assert.AreEqual(1, charCount);
        }

        [TestMethod]
        public void GetCharCount_ReturnsCorrectValue_With8BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int charCount = encoding.GetCharCount(new byte[] { 0xC2, 0x80 }, 0, 2);
            Assert.AreEqual(1, charCount);
        }

        [TestMethod]
        public void GetCharCount_ReturnsCorrectValue_With16BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int charCount = encoding.GetCharCount(new byte[] { 0xE0, 0xA0, 0x80 }, 0, 3);
            Assert.AreEqual(1, charCount);
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseByteArrayIsNull() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentNullException>(() => encoding.GetCharCount(null, 0, 1));
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseIndexIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetCharCount(new byte[] { 0x20 }, -1, 1));
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseCountIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetCharCount(new byte[] { 0x20 }, 0, -1));
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseCountIsTooLarge() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetCharCount(new byte[] { 0x20 }, 0, 100));
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseCharacterIsIncomplete() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<DecoderFallbackException>(() => encoding.GetCharCount(new byte[] { 0xC0 }, 0, 1));
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseContinuationByteIsInvalid() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<DecoderFallbackException>(() => encoding.GetCharCount(new byte[] { 0xC0, 0xC0 }, 0, 2));
        }

        [TestMethod]
        public void GetCharCount_ThrowsException_BecauseByteSequenceIsInvalid() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<DecoderFallbackException>(() => encoding.GetCharCount(new byte[] { 0xF0 }, 0, 1));
        }

        [TestMethod]
        public void GetChars_ReturnsCorrectValue() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            char[] chars = new char[1];
            encoding.GetChars(new byte[] { 0x20 }, 0, 1, chars, 0);
            CollectionAssert.AreEqual(new char[] { '\u0020' }, chars);
        }

        [TestMethod]
        public void GetChars_ReturnsCorrectValue_WithNullCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            char[] chars = new char[1];
            encoding.GetChars(new byte[] { 0xC0, 0x80 }, 0, 2, chars, 0);
            CollectionAssert.AreEqual(new char[] { '\u0000' }, chars);
        }

        [TestMethod]
        public void GetChars_ReturnsCorrectValue_With8BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            char[] chars = new char[1];
            encoding.GetChars(new byte[] { 0xC2, 0x80 }, 0, 2, chars, 0);
            CollectionAssert.AreEqual(new char[] { '\u0080' }, chars);
        }

        [TestMethod]
        public void GetChars_ReturnsCorrectValue_With16BitCharacter() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            char[] chars = new char[1];
            encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, 0, 3, chars, 0);
            CollectionAssert.AreEqual(new char[] { '\u0800' }, chars);
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseByteArrayIsNull() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentNullException>(() => encoding.GetChars(null, 0, 1, new char[1], 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseCharArrayIsNull() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentNullException>(() => encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, 0, 1, null, 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseByteIndexIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, -1, 1, new char[1], 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseByteCountIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, 0, -1, new char[1], 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseByteCountIsTooLarge() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, 0, 100, new char[1], 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseCharIndexIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, 0, 1, new char[1], -1));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseNumberOfCharsDoesNotFitInArray() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
#pragma warning disable CA1825 // Avoid zero-length array allocations
            Assert.ThrowsException<ArgumentException>(() => encoding.GetChars(new byte[] { 0xE0, 0xA0, 0x80 }, 0, 1, new char[0], 0));
#pragma warning restore CA1825 // Avoid zero-length array allocations
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseCharacterIsIncomplete() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<DecoderFallbackException>(() => encoding.GetChars(new byte[] { 0xC0 }, 0, 1, new char[1], 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseContinuationByteIsInvalid() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<DecoderFallbackException>(() => encoding.GetChars(new byte[] { 0xC0, 0xC0 }, 0, 2, new char[1], 0));
        }

        [TestMethod]
        public void GetChars_ThrowsException_BecauseByteSequenceIsInvalid() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<DecoderFallbackException>(() => encoding.GetChars(new byte[] { 0xF0 }, 0, 1, new char[1], 0));
        }

        [TestMethod]
        public void GetMaxByteCount_ReturnsCorrectValue() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int maxByteCount = encoding.GetMaxByteCount(3);
            Assert.AreEqual(9, maxByteCount);
        }

        [TestMethod]
        public void GetMaxByteCount_ThrowsException_BecauseCharCountIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetMaxByteCount(-1));
        }

        [TestMethod]
        public void GetMaxByteCount_ThrowsException_BecauseCharCountIsTooLarge() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetMaxByteCount(2147483647));
        }

        [TestMethod]
        public void GetMaxCharCount_ReturnsCorrectValue() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            int maxCharCount = encoding.GetMaxCharCount(3);
            Assert.AreEqual(3, maxCharCount);
        }

        [TestMethod]
        public void GetMaxCharCount_ThrowsException_BecauseByteCountIsNegative() {
            ModifiedUTF8Encoding encoding = new ModifiedUTF8Encoding();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => encoding.GetMaxCharCount(-1));
        }
    }
}
