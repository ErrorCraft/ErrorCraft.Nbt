using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// Represents the interface for all NBT collection types.
    /// </summary>
    public interface ICollectionTag : ITag, IEnumerable {
        /// <summary>
        /// Gets the number of items in this NBT collection.
        /// </summary>
        int Count { get; }

        /// <summary>
        /// Gets the tag at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to get.</param>
        /// <returns>The item at the specified index.</returns>
        ITag this[int index] { get; }

        /// <summary>
        /// Returns an enumerator that iterates through the <see cref="ICollectionTag"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the <see cref="ICollectionTag"/>.</returns>
        new IEnumerator<ITag> GetEnumerator();
    }

    /// <summary>
    /// Represents the generic interface for all NBT collection types.
    /// </summary>
    /// <typeparam name="T">The type of the items in the collection.</typeparam>
    public interface ICollectionTag<T> : ICollection<T>, ICollectionTag {
        /// <summary>
        /// Gets or sets the item at the specified index.
        /// </summary>
        /// <param name="index">The index of the item to get.</param>
        /// <returns>The item at the specified index.</returns>
        new T this[int index] { get; set; }
    }
}
