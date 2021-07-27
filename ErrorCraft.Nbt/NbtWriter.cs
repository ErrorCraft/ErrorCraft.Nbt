using System;
using System.IO;

namespace ErrorCraft.Nbt {
    /// <summary>
    /// A class for writing NBT to a stream.
    /// </summary>
    public class NbtWriter : IDisposable {
        private readonly BinaryWriter Writer;

        /// <summary>
        /// Initialises a new instance of the <see cref="NbtWriter"/> class with the specified stream.
        /// </summary>
        /// <param name="stream">The output stream.</param>
        public NbtWriter(Stream stream) {
            Writer = new BinaryWriter(stream);
        }

        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Writes an <see cref="NbtRoot"/> to the stream.
        /// </summary>
        /// <param name="value">The <see cref="NbtRoot"/> to write.</param>
        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <c>null</c>.</exception>
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
