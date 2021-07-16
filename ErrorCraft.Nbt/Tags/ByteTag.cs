using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a signed byte.
    /// </summary>
    public class ByteTag : INumberTag, IEquatable<ByteTag> {
        private sbyte Data;

        /// <summary>
        /// Initialises a new instance of the <see cref="ByteTag"/> class with the default value 0.
        /// </summary>
        public ByteTag() : this(0) {}

        /// <summary>
        /// Initialises a new instance of the <see cref="ByteTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public ByteTag(sbyte data) {
            Data = data;
        }

        public TagType GetTagType() {
            return TagType.BYTE;
        }

        public sbyte GetAsByte() {
            return Data;
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
            Data = binaryReader.ReadByte();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteByte(Data);
        }

        public bool Equals(ByteTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public bool Equals(INumberTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.GetAsByte();
        }

        public override bool Equals(object obj) {
            return Equals(obj as ByteTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
