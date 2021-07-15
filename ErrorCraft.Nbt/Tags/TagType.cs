namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// An enumeration of the NBT types.
    /// </summary>
    public enum TagType : sbyte {
        /// <summary>
        /// Signifies the end of a <see cref="COMPOUND"/>.
        /// </summary>
        END = 0,

        /// <summary>
        /// A single signed byte.
        /// </summary>
        BYTE = 1,

        /// <summary>
        /// A single signed 16-bit integer.
        /// </summary>
        SHORT = 2,

        /// <summary>
        /// A single signed 32-bit integer.
        /// </summary>
        INT = 3,

        /// <summary>
        /// A single signed 64-bit integer.
        /// </summary>
        LONG = 4,

        /// <summary>
        /// A single IEEE-754 single-precision floating point number.
        /// </summary>
        FLOAT = 5,

        /// <summary>
        /// A single IEEE-754 double-precision floating point number.
        /// </summary>
        DOUBLE = 6,

        /// <summary>
        /// A length-prefixed array of signed bytes.
        /// </summary>
        BYTE_ARRAY = 7,

        /// <summary>
        /// A length-prefixed string with <see cref="ModifiedUTF8Encoding"/> encoding.
        /// </summary>
        STRING = 8,

        /// <summary>
        /// A list of tags, all of the same type.
        /// </summary>
        LIST = 9,

        /// <summary>
        /// A list of named tags.
        /// </summary>
        COMPOUND = 10,

        /// <summary>
        /// A length-prefixed array of signed 32-bit integers.
        /// </summary>
        INT_ARRAY = 11,

        /// <summary>
        /// A length-prefixed array of signed 64-bit integers.
        /// </summary>
        LONG_ARRAY = 12
    }
}
