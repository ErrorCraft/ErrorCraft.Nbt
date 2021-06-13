namespace ErrorCraft.Nbt.Tags {
    public class ShortTag : INumberTag {
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
    }
}
