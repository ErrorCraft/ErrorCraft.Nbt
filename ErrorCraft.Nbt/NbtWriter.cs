using System;
using System.IO;

namespace ErrorCraft.Nbt {
    public class NbtWriter : IDisposable {
        private readonly BinaryWriter Writer;

        public NbtWriter(Stream stream) {
            Writer = new BinaryWriter(stream);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Write(NbtRoot value) {
            if (value == null) {
                throw new ArgumentNullException(nameof(value));
            }

            Writer.WriteTagType(value.Data.GetTagType());
            Writer.WriteString(value.RootName);
            value.Data.Write(Writer);
        }

        private void Dispose(bool disposing) {
            if (disposing) {
                Writer.Dispose();
            }
        }
    }
}
