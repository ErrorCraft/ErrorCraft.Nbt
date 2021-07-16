using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a signed 16-bit integer.
    /// </summary>
    public class ShortTag : INumberTag, IEquatable<ShortTag> {
        private short Data;

        /// <summary>
        /// Initialises a new instance of the <see cref="ShortTag"/> class with the default value 0.
        /// </summary>
        public ShortTag() : this(0) {}

        /// <summary>
        /// Initialises a new instance of the <see cref="ShortTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public ShortTag(short data) {
            Data = data;
        }

        public TagType GetTagType() {
            return TagType.SHORT;
        }

        public sbyte GetAsByte() {
            return (sbyte)Data;
        }

        public short GetAsShort() {
            return Data;
        }

        public int GetAsInt() {
            return Data;
        }

        public long GetAsLong() {
            return Data;
        }

        public float GetAsFloat() {
            return Data;
        }

        public double GetAsDouble() {
            return Data;
        }

        public void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadShort();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteShort(Data);
        }

        public bool Equals(ShortTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public bool Equals(INumberTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.GetAsShort();
        }

        public override bool Equals(object obj) {
            return Equals(obj as ShortTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
