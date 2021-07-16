using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a string.
    /// </summary>
    public class StringTag : ITag, IEquatable<StringTag> {
        private string Data;

        /// <summary>
        /// Initialises a new instance of the <see cref="StringTag"/> class with an empty string.
        /// </summary>
        public StringTag() : this("") {}

        /// <summary>
        /// Initialises a new instance of the <see cref="StringTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        /// <exception cref="ArgumentNullException"><paramref name="data"/> is <c>null</c>.</exception>
        public StringTag(string data) {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public TagType GetTagType() {
            return TagType.STRING;
        }

        /// <summary>
        /// Gets the string value of this tag.
        /// </summary>
        /// <returns>The string contained in this tag.</returns>
        public string GetString() {
            return Data;
        }

        public void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadString();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteString(Data);
        }


        public bool Equals(StringTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public override bool Equals(object obj) {
            return Equals(obj as StringTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
