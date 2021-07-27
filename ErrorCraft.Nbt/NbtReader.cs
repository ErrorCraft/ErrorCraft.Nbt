using ErrorCraft.Nbt.Tags;
using System;
using System.IO;

namespace ErrorCraft.Nbt {
    /// <summary>
    /// A class for reading NBT from a stream.
    /// </summary>
    public class NbtReader : IDisposable {
        private readonly BinaryReader Reader;

        /// <summary>
        /// Initialises a new instance of the <see cref="NbtReader"/> class with the specified stream.
        /// </summary>
        /// <param name="stream">The input stream.</param>
        public NbtReader(Stream stream) {
            Reader = new BinaryReader(stream);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Reads an <see cref="NbtRoot"/> from the stream.
        /// </summary>
        /// <returns>An <see cref="NbtRoot"/> read from the stream.</returns>
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
