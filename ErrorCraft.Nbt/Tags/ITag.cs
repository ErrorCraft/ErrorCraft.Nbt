namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// Represents the base interface for all NBT types.
    /// </summary>
    public interface ITag {
        /// <summary>
        /// Gets the <see cref="TagType"/> associated with this tag.
        /// </summary>
        TagType GetTagType();

        /// <summary>
        /// Reads the contents of the <see cref="BinaryReader"/> into this tag.
        /// </summary>
        /// <param name="binaryReader">The reader to read bytes from.</param>
        void Read(BinaryReader binaryReader);

        /// <summary>
        /// Writes the contents of this tag into the <see cref="BinaryWriter"/>.
        /// </summary>
        /// <param name="binaryWriter">The writer to write bytes to.</param>
        void Write(BinaryWriter binaryWriter);
    }
}
