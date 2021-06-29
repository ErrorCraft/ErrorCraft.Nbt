using System;

namespace ErrorCraft.Nbt.Tags {
    public class ShortTag : INumberTag, IEquatable<ShortTag> {
        private short Data;

        public ShortTag() : this(0) {}

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
