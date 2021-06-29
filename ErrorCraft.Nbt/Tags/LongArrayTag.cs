using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class LongArrayTag : ICollectionTag<long> {
        private long[] Data;

        public int Count { get { return Data.Length; } }
        public bool IsReadOnly { get { return false; } }

        public LongArrayTag() : this(Array.Empty<long>()) {}

        public LongArrayTag(long[] data) {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public long this[int index] {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

        ITag ICollectionTag.this[int index] { get { return new LongTag(Data[index]); } }

        public TagType GetTagType() {
            return TagType.LONG_ARRAY;
        }

        public void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new long[length];
            for (int i = 0; i < length; i++) {
                Data[i] = binaryReader.ReadLong();
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteInt(Data.Length);
            for (int i = 0; i < Data.Length; i++) {
                binaryWriter.WriteLong(Data[i]);
            }
        }

        void ICollection<long>.Add(long item) {
            throw new NotSupportedException();
        }

        void ICollection<long>.Clear() {
            throw new NotSupportedException();
        }

        bool ICollection<long>.Remove(long item) {
            throw new NotSupportedException();
        }

        public bool Contains(long item) {
            return Array.IndexOf(Data, item) > -1;
        }

        public void CopyTo(long[] array, int arrayIndex) {
            Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<long> GetEnumerator() {
            foreach (long l in Data) {
                yield return l;
            }
        }

        IEnumerator<ITag> ICollectionTag.GetEnumerator() {
            foreach (long l in this) {
                yield return new LongTag(l);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
