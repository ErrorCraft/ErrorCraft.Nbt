using System;
using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class ByteArrayTag : ICollectionTag<sbyte> {
        private sbyte[] Data;

        public int Count { get { return Data.Length; } }

        public ByteArrayTag() : this(Array.Empty<sbyte>()) { }

        public ByteArrayTag(sbyte[] data) {
            Data = data;
        }

        public sbyte this[int index] {
            get { return Data[index]; }
            set { Data[index] = value; }
        }

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

        public IEnumerator<sbyte> GetEnumerator() {
            foreach (sbyte b in Data) {
                yield return b;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
