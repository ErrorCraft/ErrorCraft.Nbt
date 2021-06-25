using System;
using System.Text;

namespace ErrorCraft.Nbt {
    public class ModifiedUTF8Encoding : Encoding {
        private const byte CONTINUATION_BYTE = 0x80;
        private const byte CONTINUATION_BYTE_MASK = 0xC0;
        private const byte CONTINUATION_BYTE_CONTENTS_MASK = 0x3F;
        private const string INVALID_BYTE_SEQUENCE_MESSAGE = "Invalid byte sequence [{0:X2}]";
        private const string INVALID_CONTINUATION_BYTE_MESSAGE = "Invalid continuation byte [{0:X2}]";
        private const string INCOMPLETE_CHARACTER_MESSAGE = "Incomplete character at end, expected another byte.";
        private const string OUTPUT_BYTE_BUFFER_TOO_SMALL_MESSAGE = "The output byte buffer is too small to contain the encoded bytes.";
        private const string OUTPUT_CHAR_BUFFER_TOO_SMALL_MESSAGE = "The output char buffer is too small to contain the decoded characters.";
        private const int MAX_BYTES_PER_CHAR = 3;
        private const char NULL_CHARACTER = '\u0000';
        private const char MAX_SINGLE_BYTE_CHARACTER = '\u007F';
        private const char MAX_DOUBLE_BYTE_CHARACTER = '\u07FF';

        public override int GetByteCount(char[] chars, int index, int count) {
            if (chars == null) {
                throw new ArgumentNullException(nameof(chars));
            }
            if (index < 0) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (count < 0) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (chars.Length - index < count) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int byteCount = 0;
            for (int i = index; i < index + count; i++) {
                byteCount += GetByteCount(chars[i]);
            }
            return byteCount;
        }

        public override int GetBytes(char[] chars, int charIndex, int charCount, byte[] bytes, int byteIndex) {
            if (chars == null) {
                throw new ArgumentNullException(nameof(chars));
            }
            if (bytes == null) {
                throw new ArgumentNullException(nameof(bytes));
            }
            if (charIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(charIndex));
            }
            if (charCount < 0) {
                throw new ArgumentOutOfRangeException(nameof(charCount));
            }
            if (chars.Length - charIndex < charCount) {
                throw new ArgumentOutOfRangeException(nameof(charCount));
            }
            if (byteIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(byteIndex));
            }
            if (bytes.Length - byteIndex < GetByteCount(chars)) {
                throw new ArgumentException(OUTPUT_BYTE_BUFFER_TOO_SMALL_MESSAGE);
            }

            int byteOffset = 0;
            for (int i = charIndex; i < charIndex + charCount; i++) {
                byteOffset += GetBytes(chars[i], bytes, byteIndex + byteOffset);
            }
            return byteOffset;
        }

        public override int GetCharCount(byte[] bytes, int index, int count) {
            if (bytes == null) {
                throw new ArgumentNullException(nameof(bytes));
            }
            if (index < 0) {
                throw new ArgumentOutOfRangeException(nameof(index));
            }
            if (count < 0) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }
            if (bytes.Length - index < count) {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            int writtenChars = 0;
            int byteOffset = 0;
            while (byteOffset < bytes.Length) {
                byteOffset += GetNextByteCount(bytes, index + byteOffset);
                writtenChars++;
            }
            return writtenChars;
        }

        public override int GetChars(byte[] bytes, int byteIndex, int byteCount, char[] chars, int charIndex) {
            if (bytes == null) {
                throw new ArgumentNullException(nameof(bytes));
            }
            if (chars == null) {
                throw new ArgumentNullException(nameof(chars));
            }
            if (byteIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(charIndex));
            }
            if (byteCount < 0) {
                throw new ArgumentOutOfRangeException(nameof(byteCount));
            }
            if (bytes.Length - byteIndex < byteCount) {
                throw new ArgumentOutOfRangeException(nameof(byteCount));
            }
            if (charIndex < 0) {
                throw new ArgumentOutOfRangeException(nameof(charIndex));
            }
            if (chars.Length - charIndex < GetCharCount(bytes)) {
                throw new ArgumentException(OUTPUT_CHAR_BUFFER_TOO_SMALL_MESSAGE);
            }

            int writtenChars = 0;
            int byteOffset = 0;
            while (byteOffset < byteCount) {
                byteOffset += GetChar(bytes, byteIndex + byteOffset, chars, charIndex + writtenChars);
                writtenChars++;
            }
            return writtenChars;
        }

        public override int GetMaxByteCount(int charCount) {
            if (charCount < 0) {
                throw new ArgumentOutOfRangeException(nameof(charCount));
            }

            long byteCount = (long)charCount * MAX_BYTES_PER_CHAR;
            if (byteCount > int.MaxValue) {
                throw new ArgumentOutOfRangeException(nameof(charCount));
            }
            return (int)byteCount;
        }

        public override int GetMaxCharCount(int byteCount) {
            if (byteCount < 0) {
                throw new ArgumentOutOfRangeException(nameof(byteCount));
            }
            return byteCount;
        }

        private static int GetByteCount(char c) {
            if (c == NULL_CHARACTER) {
                return 2;
            }
            if (c <= MAX_SINGLE_BYTE_CHARACTER) {
                return 1;
            }
            if (c <= MAX_DOUBLE_BYTE_CHARACTER) {
                return 2;
            }
            return 3;
        }

        private static int GetNextByteCount(byte[] bytes, int index) {
            byte b = bytes[index];
            if ((b & 0x80) == 0x00) {
                return 1;
            }
            if ((b & 0xE0) == 0xC0) {
                if (index + 1 >= bytes.Length) {
                    throw new DecoderFallbackException(INCOMPLETE_CHARACTER_MESSAGE);
                }
                byte b2 = bytes[index + 1];
                if ((b2 & CONTINUATION_BYTE_MASK) != CONTINUATION_BYTE) {
                    throw new DecoderFallbackException(string.Format(INVALID_CONTINUATION_BYTE_MESSAGE, b2));
                }
                return 2;
            }
            if ((b & 0xF0) == 0xE0) {
                if (index + 2 >= bytes.Length) {
                    throw new DecoderFallbackException(INCOMPLETE_CHARACTER_MESSAGE);
                }
                byte b2 = bytes[index + 1];
                byte b3 = bytes[index + 2];
                if ((b2 & CONTINUATION_BYTE_MASK) != CONTINUATION_BYTE) {
                    throw new DecoderFallbackException(string.Format(INVALID_CONTINUATION_BYTE_MESSAGE, b2));
                }
                if ((b3 & CONTINUATION_BYTE_MASK) != CONTINUATION_BYTE) {
                    throw new DecoderFallbackException(string.Format(INVALID_CONTINUATION_BYTE_MESSAGE, b3));
                }
                return 3;
            }
            throw new DecoderFallbackException(string.Format(INVALID_BYTE_SEQUENCE_MESSAGE, b));
        }

        private static int GetBytes(char c, byte[] bytes, int index) {
            if (c <= MAX_SINGLE_BYTE_CHARACTER && c != NULL_CHARACTER) {
                bytes[index] = (byte)c;
                return 1;
            }
            if (c <= MAX_DOUBLE_BYTE_CHARACTER) {
                bytes[index] = (byte)(0xC0 | ((c >> 6) & 0x1F));
                bytes[index + 1] = (byte)(CONTINUATION_BYTE | (c & CONTINUATION_BYTE_CONTENTS_MASK));
                return 2;
            }
            bytes[index] = (byte)(0xE0 | ((c >> 12) & 0x0F));
            bytes[index + 1] = (byte)(CONTINUATION_BYTE | ((c >> 6) & CONTINUATION_BYTE_CONTENTS_MASK));
            bytes[index + 2] = (byte)(CONTINUATION_BYTE | (c & CONTINUATION_BYTE_CONTENTS_MASK));
            return 3;
        }

        private static int GetChar(byte[] bytes, int byteIndex, char[] chars, int charIndex) {
            int nextByteCount = GetNextByteCount(bytes, byteIndex);
            chars[charIndex] = nextByteCount switch {
                1 => (char)bytes[byteIndex],
                2 => (char)(((bytes[byteIndex] & 0x1F) << 6) | (bytes[byteIndex + 1] & CONTINUATION_BYTE_CONTENTS_MASK)),
                3 => (char)(((bytes[byteIndex] & 0x0F) << 12) | ((bytes[byteIndex + 1] & CONTINUATION_BYTE_CONTENTS_MASK) << 6) | (bytes[byteIndex + 2] & CONTINUATION_BYTE_CONTENTS_MASK)),
                _ => throw new DecoderFallbackException(string.Format(INVALID_BYTE_SEQUENCE_MESSAGE, bytes[byteIndex]))
            };
            return nextByteCount;
        }
    }
}
