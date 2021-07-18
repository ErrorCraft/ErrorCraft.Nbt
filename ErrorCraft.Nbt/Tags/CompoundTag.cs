using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a collection of named tags.
    /// </summary>
    public class CompoundTag : ITag, IEnumerable<KeyValuePair<string, ITag>> {
        private Dictionary<string, ITag> Data;

        /// <summary>
        /// Gets the number of items in this NBT compound.
        /// </summary>
        public int Count { get { return Data.Count; } }

        /// <summary>
        /// Initialises a new instance of the <see cref="CompoundTag"/> class with an empty collection of tags.
        /// </summary>
        public CompoundTag() : this(new Dictionary<string, ITag>()) { }

        /// <summary>
        /// Initialises a new instance of the <see cref="CompoundTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public CompoundTag(Dictionary<string, ITag> data) {
            Data = new Dictionary<string, ITag>(data);
        }

        /// <summary>
        /// Gets or sets the tag associated with the specified name.
        /// </summary>
        /// <param name="key">The name of the tag to get or set.</param>
        /// <returns>The tag accociated with the specified name.</returns>
        public ITag this[string key] {
            get { return Data[key]; }
            set { Data[key] = value; }
        }

        public TagType GetTagType() {
            return TagType.COMPOUND;
        }

        public void Read(BinaryReader binaryReader) {
            Data = new Dictionary<string, ITag>();
            TagType tagType;
            while ((tagType = binaryReader.ReadTagType()) != TagType.END) {
                string key = binaryReader.ReadString();
                ITag value = TagFactory.GetEmptyTag(tagType);
                value.Read(binaryReader);
                Data[key] = value;
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            foreach (KeyValuePair<string, ITag> pair in Data) {
                binaryWriter.WriteTagType(pair.Value.GetTagType());
                binaryWriter.WriteString(pair.Key);
                pair.Value.Write(binaryWriter);
            }
            binaryWriter.WriteTagType(TagType.END);
        }

        public IEnumerator<KeyValuePair<string, ITag>> GetEnumerator() {
            foreach (KeyValuePair<string, ITag> pair in Data) {
                yield return pair;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds the specified name and tag to the compound.
        /// </summary>
        /// <param name="key">The name of the tag to add.</param>
        /// <param name="value">The value to add.</param>
        public void Add(string key, ITag value) {
            Data.Add(key, value);
        }
    }
}
