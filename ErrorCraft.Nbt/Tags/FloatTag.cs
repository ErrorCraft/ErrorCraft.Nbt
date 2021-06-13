namespace ErrorCraft.Nbt.Tags {
    public class FloatTag : INumberTag {
        private float Data;

        public FloatTag() : this(0.0f) {}

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
    }
}
