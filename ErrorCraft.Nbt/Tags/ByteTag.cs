namespace ErrorCraft.Nbt.Tags {
    public class ByteTag : INumberTag {
        private readonly sbyte Data;

        public ByteTag() : this(0) {}

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
    }
}
