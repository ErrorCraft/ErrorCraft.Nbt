using System;

namespace ErrorCraft.Nbt.Tags {
    public class StringTag : ITag {
        private string Data;

        public StringTag() : this("") {}

        public StringTag(string data) {
            Data = data ?? throw new ArgumentNullException(nameof(data));
        }

        public TagType GetTagType() {
            return TagType.STRING;
        }

        public string GetString() {
            return Data;
        }

        public void Read(BinaryReader binaryReader) {
            Data = binaryReader.ReadString();
        }

        public void Write(BinaryWriter binaryWriter) {
            binaryWriter.WriteString(Data);
        }
    }
}
