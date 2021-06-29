using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public interface ICollectionTag : ITag, IEnumerable {
        int Count { get; }
        ITag this[int index] { get; }
        new IEnumerator<ITag> GetEnumerator();
    }

    public interface ICollectionTag<T> : ICollection<T>, ICollectionTag {
        new T this[int index] { get; set; }
    }
}
