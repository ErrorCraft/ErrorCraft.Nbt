using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class ByteArrayTag : ICollectionTag<sbyte> {
        private sbyte[] Data;

        public int Count { get { return Data.Length; } }
        public bool IsReadOnly { get { return false; } }

        public ByteArrayTag() : this(Array.Empty<sbyte>()) {}

        public ByteArrayTag(sbyte[] data) {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public sbyte this[int index] {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

        ITag ICollectionTag.this[int index] { get { return new ByteTag(Data[index]); } }

        public TagType GetTagType() {
            return TagType.BYTE_ARRAY;
        }

        public void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new sbyte[length];
            for (int i = 0; i < length; i++) {
                Data[i] = binaryReader.ReadByte();
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteInt(Data.Length);
            for (int i = 0; i < Data.Length; i++) {
                binaryWriter.WriteByte(Data[i]);
            }
        }

        void ICollection<sbyte>.Add(sbyte item) {
            throw new NotSupportedException();
        }

        void ICollection<sbyte>.Clear() {
            throw new NotSupportedException();
        }

        bool ICollection<sbyte>.Remove(sbyte item) {
            throw new NotSupportedException();
        }

        public bool Contains(sbyte item) {
            return Array.IndexOf(Data, item) > -1;
        }

        public void CopyTo(sbyte[] array, int arrayIndex) {
            Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<sbyte> GetEnumerator() {
            foreach (sbyte b in Data) {
                yield return b;
            }
        }

        IEnumerator<ITag> ICollectionTag.GetEnumerator() {
            foreach (sbyte b in this) {
                yield return new ByteTag(b);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
