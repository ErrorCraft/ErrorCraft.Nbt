using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class ListTag : ICollectionTag<ITag> {
        private const string INVALID_TAG_TYPE_MESSAGE = "Cannot add {0} to list of type {1}.";

        private List<ITag> Data;
        private TagType ElementType;

        public int Count { get { return Data.Count; } }
        public bool IsReadOnly { get { return false; } }

        public ListTag() {
            Data = new List<ITag>();
            ElementType = TagType.BYTE;
        }

        public ITag this[int index] {
            get { return Data[index]; }
            set {
                if (!UpdateElementType(value)) {
                    throw new ArgumentException(string.Format(INVALID_TAG_TYPE_MESSAGE, value.GetTagType(), ElementType));
                }
                Data[index] = value;
            }
        }

        public TagType GetTagType() {
            return TagType.LIST;
        }

        public void Read(BinaryReader binaryReader) {
            ElementType = binaryReader.ReadTagType();
            int length = binaryReader.ReadInt();
            Data = new List<ITag>(length);
            for (int i = 0; i < length; i++) {
                ITag element = TagFactory.GetEmptyTag(ElementType);
                element.Read(binaryReader);
                Data.Add(element);
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteTagType(ElementType);
            binaryWriter.WriteInt(Data.Count);
            for (int i = 0; i < Data.Count; i++) {
                Data[i].Write(binaryWriter);
            }
        }

        public void Add(ITag item) {
            if (!UpdateElementType(item)) {
                throw new ArgumentException(string.Format(INVALID_TAG_TYPE_MESSAGE, item.GetTagType(), ElementType));
            }
            Data.Add(item);
        }

        public void Clear() {
            Data.Clear();
        }

        public bool Remove(ITag item) {
            return Data.Remove(item);
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

        public TagType GetElementTagType() {
            return ElementType;
        }

        private bool UpdateElementType(ITag tag) {
            if (Data.Count == 0) {
                ElementType = tag.GetTagType();
                return true;
            }
            return ElementType == tag.GetTagType();
        }
    }
}
