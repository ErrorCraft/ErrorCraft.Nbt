using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing a list of tags, all of the same type.
    /// </summary>
    public class ListTag : ICollectionTag<ITag> {
        private const string INVALID_TAG_TYPE_MESSAGE = "Cannot add {0} to list of type {1}.";
        private const string MISSING_TAG_TYPE_MESSAGE = "Missing type for list";

        private List<ITag> Data;
        private TagType ElementTagType;

        public int Count { get { return Data.Count; } }
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Initialises a new instance of the <see cref="ListTag"/> class with an empty list and the element tag type set to <see cref="TagType.END"/>.
        /// </summary>
        public ListTag() {
            Data = new List<ITag>();
            ElementTagType = TagType.END;
        }

        public ITag this[int index] {
            get { return Data[index]; }
            set {
                if (!UpdateElementType(value)) {
                    throw new ArgumentException(string.Format(INVALID_TAG_TYPE_MESSAGE, value.GetTagType(), ElementTagType));
                }
                Data[index] = value;
            }
        }

        public TagType GetTagType() {
            return TagType.LIST;
        }

        public void Read(BinaryReader binaryReader) {
            ElementTagType = binaryReader.ReadTagType();
            int length = binaryReader.ReadInt();
            if (ElementTagType == TagType.END && length > 0) {
                throw new ArgumentException(MISSING_TAG_TYPE_MESSAGE);
            }
            Data = new List<ITag>(length);
            for (int i = 0; i < length; i++) {
                ITag element = TagFactory.GetEmptyTag(ElementTagType);
                element.Read(binaryReader);
                Data.Add(element);
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteTagType(ElementTagType);
            binaryWriter.WriteInt(Data.Count);
            for (int i = 0; i < Data.Count; i++) {
                Data[i].Write(binaryWriter);
            }
        }

        public void Add(ITag item) {
            if (!UpdateElementType(item)) {
                throw new ArgumentException(string.Format(INVALID_TAG_TYPE_MESSAGE, item.GetTagType(), ElementTagType));
            }
            Data.Add(item);
        }

        public void Clear() {
            Data.Clear();
            ElementTagType = TagType.END;
        }

        public bool Remove(ITag item) {
            if (Data.Remove(item)) {
                UpdateElementTypeAfterRemove();
                return true;
            }
            return false;
        }

        public bool Contains(ITag item) {
            return Data.Contains(item);
        }

        public void CopyTo(ITag[] array, int arrayIndex) {
            Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ITag> GetEnumerator() {
            foreach (ITag tag in Data) {
                yield return tag;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        /// <summary>
        /// Gets the <see cref="TagType"/> of the elements in this list.
        /// </summary>
        /// <returns>The <see cref="TagType"/> of the elements in this list.</returns>
        public TagType GetElementTagType() {
            return ElementTagType;
        }

        private bool UpdateElementType(ITag tag) {
            if (Data.Count == 0) {
                ElementTagType = tag.GetTagType();
                return true;
            }
            return ElementTagType == tag.GetTagType();
        }

        private void UpdateElementTypeAfterRemove() {
            if (Data.Count == 0) {
                ElementTagType = TagType.END;
            }
        }
    }
}
