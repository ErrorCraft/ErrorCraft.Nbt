using ErrorCraft.Nbt.Tags;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class NbtWriterTests {
        [TestMethod]
        public void Write_WritesCorrectValue() {
            NbtRoot nbtRoot = new NbtRoot("foo", new ByteTag(0));
            using MemoryStream memoryStream = new MemoryStream();
            using NbtWriter nbtWriter = new NbtWriter(memoryStream);

            nbtWriter.Write(nbtRoot);
            byte[] bytes = memoryStream.ToArray();
            CollectionAssert.AreEqual(new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x00 }, bytes);
        }

        [TestMethod]
        public void Write_ThrowsException_BecauseNbtRootIsNull() {
            using MemoryStream memoryStream = new MemoryStream();
            using NbtWriter nbtWriter = new NbtWriter(memoryStream);

            Assert.ThrowsException<ArgumentNullException>(() => nbtWriter.Write(null));
        }
    }
}
