using System;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a signed 64-bit integer.
    /// </summary>
    public class LongTag : INumberTag, IEquatable<LongTag> {
        private long Data;

        /// <summary>
        /// Initialises a new instance of the <see cref="LongTag"/> class with the default value 0.
        /// </summary>
        public LongTag() : this(0L) {}

        /// <summary>
        /// Initialises a new instance of the <see cref="LongTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public LongTag(long data) {
            Data = data;
        }

        public TagType GetTagType() {
            return TagType.LONG;
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
            return Data;
        }

        public float GetAsFloat() {
            return Data;
        }

        public double GetAsDouble() {
            return Data;
        }

        public void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadLong();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteLong(Data);
        }

        public bool Equals(LongTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public bool Equals(INumberTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.GetAsLong();
        }

        public override bool Equals(object obj) {
            return Equals(obj as LongTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
