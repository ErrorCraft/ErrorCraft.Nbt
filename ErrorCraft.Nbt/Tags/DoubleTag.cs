using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a double-precision floating point number.
    /// </summary>
    public class DoubleTag : INumberTag, IEquatable<DoubleTag> {
        private double Data;

        /// <summary>
        /// Initialises a new instance of the <see cref="DoubleTag"/> class with the default value 0.
        /// </summary>
        public DoubleTag() : this(0.0d) {}

        /// <summary>
        /// Initialises a new instance of the <see cref="DoubleTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public DoubleTag(double data) {
            Data = data;
        }

        public TagType GetTagType() {
            return TagType.DOUBLE;
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
            return (float)Data;
        }

        public double GetAsDouble() {
            return Data;
        }

        public void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadDouble();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteDouble(Data);
        }

        public bool Equals(DoubleTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public bool Equals(INumberTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.GetAsDouble();
        }

        public override bool Equals(object obj) {
            return Equals(obj as DoubleTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
