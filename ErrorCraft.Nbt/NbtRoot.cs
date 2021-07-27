using ErrorCraft.Nbt.Tags;

namespace ErrorCraft.Nbt {
    /// <summary>
    /// Represents a class containing NBT data.
    /// </summary>
    public class NbtRoot {
        /// <summary>
        /// The root name of the NBT.
        /// </summary>
        public string RootName { get; }

        /// <summary>
        /// The tag contents of the NBT.
        /// </summary>
        public ITag Data { get; }

        /// <summary>
        /// Initialises a new instance of the <see cref="NbtRoot"/> class with the specified root name and tag.
        /// </summary>
        /// <param name="rootName">The root name of the NBT.</param>
        /// <param name="data">The tag contents of the NBT.</param>
        public NbtRoot(string rootName, ITag data) {
            RootName = rootName;
            Data = data;
        }
    }
}
