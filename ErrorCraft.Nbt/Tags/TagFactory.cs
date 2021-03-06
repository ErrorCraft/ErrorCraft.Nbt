using System;

namespace ErrorCraft.Nbt.Tags {
    public static class TagFactory {
        /// <summary>
        /// Gets an empty tag from the specified <see cref="TagType"/>.
        /// </summary>
        /// <param name="tagType">The type of the tag to get an empty <see cref="ITag"/> from.</param>
        /// <returns>An empty <see cref="ITag"/>.</returns>
        public static ITag GetEmptyTag(TagType tagType) {
            return tagType switch {
                TagType.BYTE => new ByteTag(),
                TagType.SHORT => new ShortTag(),
                TagType.INT => new IntTag(),
                TagType.LONG => new LongTag(),
                TagType.FLOAT => new FloatTag(),
                TagType.DOUBLE => new DoubleTag(),
                TagType.BYTE_ARRAY => new ByteArrayTag(),
                TagType.STRING => new StringTag(),
                TagType.LIST => new ListTag(),
                TagType.COMPOUND => new CompoundTag(),
                TagType.INT_ARRAY => new IntArrayTag(),
                TagType.LONG_ARRAY => new LongArrayTag(),
                _ => throw new ArgumentOutOfRangeException(nameof(tagType))
            };
        }
    }
}
