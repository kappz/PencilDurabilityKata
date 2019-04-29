using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilDurabilityKataProject;

namespace PencilDurabilityKataTests
{
    [TestClass]
    public class UnitTests
    {
        WriterActions writer;

        [TestInitialize]
        public void Setup()
        {
            writer = new WriterActions();
        }

        // Verify Write Functionality
        [TestMethod]
        public void InitialWordWritten()
        {
            string testInput = "How"; 
            writer.items.writersPencil.charactersToWrite = testInput;
            writer.items.paper += writer.items.writersPencil.charactersToWrite;

            Assert.AreEqual(testInput, writer.items.paper);
        }
    }
}
