using ErrorCraft.Nbt.Tags;
using System;
using System.IO;

namespace ErrorCraft.Nbt {
    public class NbtReader : IDisposable {
        private readonly BinaryReader Reader;

        public NbtReader(Stream stream) {
            Reader = new BinaryReader(stream);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public NbtRoot Read() {
            TagType tagType = Reader.ReadTagType();
            string rootName = Reader.ReadString();
            ITag tag = TagFactory.GetEmptyTag(tagType);
            tag.Read(Reader);
            return new NbtRoot(rootName, tag);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Reader.Dispose();
            }
        }
    }
}
