namespace ErrorCraft.Nbt.Tags {
    public class DoubleTag : INumberTag {
        private double Data;

        public DoubleTag() : this(0.0d) {}

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
    }
}
