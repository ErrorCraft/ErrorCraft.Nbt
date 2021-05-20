namespace ErrorCraft.Nbt.Tags {
    public class LongTag : INumberTag {
        private readonly long Data;

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
    }
}
