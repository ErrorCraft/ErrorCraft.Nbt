using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    /// <summary>
    /// A tag containing an array of signed 32-bit integers.
    /// </summary>
    public class IntArrayTag : ICollectionTag<int> {
        private int[] Data;

        public int Count { get { return Data.Length; } }
        public bool IsReadOnly { get { return false; } }

        /// <summary>
        /// Initialises a new instance of the <see cref="IntArrayTag"/> class with an empty array.
        /// </summary>
        public IntArrayTag() : this(Array.Empty<int>()) {}

        /// <summary>
        /// Initialises a new instance of the <see cref="IntArrayTag"/> class with the specified value.
        /// </summary>
        /// <param name="data">The value of this tag.</param>
        public IntArrayTag(int[] data) {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public int this[int index] {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

        ITag ICollectionTag.this[int index] { get { return new IntTag(Data[index]); } }

        public TagType GetTagType() {
            return TagType.INT_ARRAY;
        }

        public void Read(BinaryReader binaryReader) {
            int length = binaryReader.ReadInt();
            Data = new int[length];
            for (int i = 0; i < length; i++) {
                Data[i] = binaryReader.ReadInt();
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteInt(Data.Length);
            for (int i = 0; i < Data.Length; i++) {
                binaryWriter.WriteInt(Data[i]);
            }
        }

        void ICollection<int>.Add(int item) {
            throw new NotSupportedException();
        }

        void ICollection<int>.Clear() {
            throw new NotSupportedException();
        }

        bool ICollection<int>.Remove(int item) {
            throw new NotSupportedException();
        }

        public bool Contains(int item) {
            return Array.IndexOf(Data, item) > -1;
        }

        public void CopyTo(int[] array, int arrayIndex) {
            Data.CopyTo(array, arrayIndex);
        }

        public IEnumerator<int> GetEnumerator() {
            foreach (int i in Data) {
                yield return i;
            }
        }

        IEnumerator<ITag> ICollectionTag.GetEnumerator() {
            foreach (int i in this) {
                yield return new IntTag(i);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
