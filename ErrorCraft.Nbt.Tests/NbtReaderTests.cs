using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace ErrorCraft.Nbt.Tests {
    [TestClass]
    public class NbtReaderTests {
        [TestMethod]
        public void Read_ReturnsCorrectValue() {
            byte[] bytes = new byte[] { 0x01, 0x00, 0x03, 0x66, 0x6F, 0x6F, 0x00 };
            using MemoryStream memoryStream = new MemoryStream(bytes);
            using NbtReader nbtReader = new NbtReader(memoryStream);

            NbtRoot nbtRoot = nbtReader.Read();
            Assert.AreEqual("foo", nbtRoot.RootName);
        }
    }
}
