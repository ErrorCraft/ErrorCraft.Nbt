using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a single-precision floating point number.
    /// </summary>
    public class FloatTag : INumberTag, IEquatable<FloatTag> {
        private float Data;

        /// <summary>
        /// Initialises a new instance of the <see cref="FloatTag"/> class with the default value 0.
        /// </summary>
        public FloatTag() : this(0.0f) {}

        /// <summary>
        /// Initialises a new instance of the <see cref="FloatTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public FloatTag(float data) {
            Data = data;
        }

        public TagType GetTagType() {
            return TagType.FLOAT;
        }

        public sbyte GetAsByte() {
            return (sbyte)Data;
        }

        public short GetAsShort() {
            return (short)Data;
        }

        public int GetAsInt() {
            return (int)Data;
        }

        public long GetAsLong() {
            return (long)Data;
        }

        public float GetAsFloat() {
            return Data;
        }

        public double GetAsDouble() {
            return Data;
        }

        public void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadFloat();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteFloat(Data);
        }

        public bool Equals(FloatTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public bool Equals(INumberTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.GetAsFloat();
        }

        public override bool Equals(object obj) {
            return Equals(obj as FloatTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
