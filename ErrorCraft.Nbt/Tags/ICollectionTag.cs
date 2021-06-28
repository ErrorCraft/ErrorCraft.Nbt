using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public interface ICollectionTag<T> : ITag, ICollection<T> {
        T this[int index] { get; set; }
    }
}
