using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class LongArrayTag : ICollectionTag<long> {
        private long[] Data;

        public int Count { get { return Data.Length; } }

        public LongArrayTag() : this(Array.Empty<long>()) {}

        public LongArrayTag(long[] data) {
            Data = data;
        }

        public long this[int index] {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

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

        public IEnumerator<long> GetEnumerator() {
            foreach (long l in Data) {
                yield return l;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
