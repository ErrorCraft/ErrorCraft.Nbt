using System.Collections;
using System.Collections.Generic;

namespace ErrorCraft.Nbt.Tags {
    public class CompoundTag : ITag, IEnumerable<KeyValuePair<string, ITag>> {
        private Dictionary<string, ITag> Data;

        public int Count { get { return Data.Count; } }

        public CompoundTag() : this(new Dictionary<string, ITag>()) { }

        public CompoundTag(Dictionary<string, ITag> data) {
            Data = data;
        }

        public ITag this[string key] {
            get { return Data[key]; }
            set { Data[key] = value; }
        }

        public TagType GetTagType() {
            return TagType.COMPOUND;
        }

        public void Read(BinaryReader binaryReader) {
            Data = new Dictionary<string, ITag>();
            TagType tagType;
            while ((tagType = binaryReader.ReadTagType()) != TagType.END) {
                string key = binaryReader.ReadString();
                ITag value = TagFactory.GetEmptyTag(tagType);
                value.Read(binaryReader);
                Data[key] = value;
            }
        }

        public void Write(BinaryWriter binaryWriter) {
            foreach (KeyValuePair<string, ITag> pair in Data) {
                binaryWriter.WriteTagType(pair.Value.GetTagType());
                binaryWriter.WriteString(pair.Key);
                pair.Value.Write(binaryWriter);
            }
            binaryWriter.WriteTagType(TagType.END);
        }

        public IEnumerator<KeyValuePair<string, ITag>> GetEnumerator() {
            foreach (KeyValuePair<string, ITag> pair in Data) {
                yield return pair;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }
    }
}
