using ErrorCraft.Nbt.Tags;

namespace ErrorCraft.Nbt {
    public class NbtRoot {
        public string RootName { get; }
        public ITag Data { get; }

        public NbtRoot(string rootName, ITag data) {
            RootName = rootName;
            Data = data;
        }
    }
}
