using System;

namespace ErrorCraft.Nbt.Tags {
    public class IntTag : INumberTag, IEquatable<IntTag> {
        private int Data;

        public IntTag() : this(0) {}

        public IntTag(int data) {
            Data = data;
        }

        public TagType GetTagType() {
            return TagType.INT;
        }

        public sbyte GetAsByte() {
            return (sbyte)Data;
        }

        public short GetAsShort() {
            return (short)Data;
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
            Data = binaryReader.ReadInt();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteInt(Data);
        }

        public bool Equals(IntTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.Data;
        }

        public bool Equals(INumberTag other) {
            if (other == null) {
                return false;
            }
            return Data == other.GetAsInt();
        }

        public override bool Equals(object obj) {
            return Equals(obj as IntTag);
        }

        public override int GetHashCode() {
            return HashCode.Combine(Data);
        }
    }
}
