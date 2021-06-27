using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public interface ICollectionTag<T> : ITag, IEnumerable<T> {
        int Count { get; }
        T this[int index] { get; set; }
    }
}
