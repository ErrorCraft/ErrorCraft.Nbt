using System;

namespace ErrorCraft.Nbt.Tags {
    public class ByteArrayTag : ITag {
        private sbyte[] Data;

        public int Count { get { return Data.Length; } }

        public ByteArrayTag() : this(Array.Empty<sbyte>()) { }

        public ByteArrayTag(sbyte[] data) {
            Data = data;
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
    }
}
