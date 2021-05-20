namespace ErrorCraft.Nbt.Tags {
    public class ByteTag : ITag {
        public TagType GetTagType() {
            return TagType.BYTE;
        }
    }
}
