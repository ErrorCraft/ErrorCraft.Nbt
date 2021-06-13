namespace ErrorCraft.Nbt.Tags {
    public interface ITag {
        TagType GetTagType();
        void Read(BinaryReader binaryReader);
        void Write(BinaryWriter binaryWriter);
    }
}
