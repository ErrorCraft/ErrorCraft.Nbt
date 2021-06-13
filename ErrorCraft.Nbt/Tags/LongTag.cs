namespace ErrorCraft.Nbt.Tags {
    public class LongTag : INumberTag {
        private long Data;

        public LongTag() : this(0L) {}

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
    }
}
