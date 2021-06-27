using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class IntArrayTag : ICollectionTag<int> {
        private int[] Data;

        public int Count { get { return Data.Length; } }

        public IntArrayTag() : this(Array.Empty<int>()) {}

        public IntArrayTag(int[] data) {
            Data = data;
        }

        public int this[int index] {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

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

        public IEnumerator<int> GetEnumerator() {
            foreach (int i in Data) {
                yield return i;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
