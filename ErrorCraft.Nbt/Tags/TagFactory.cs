using System;

namespace ErrorCraft.Nbt.Tags {
    public static class TagFactory {
        public static ITag GetEmptyTag(TagType tagType) {
            return tagType switch {
                TagType.BYTE => new ByteTag(),
                TagType.SHORT => new ShortTag(),
                TagType.INT => new IntTag(),
                TagType.LONG => new LongTag(),
                TagType.FLOAT => new FloatTag(),
                TagType.DOUBLE => new DoubleTag(),
                _ => throw new ArgumentOutOfRangeException(nameof(tagType))
            };
        }
    }
}
