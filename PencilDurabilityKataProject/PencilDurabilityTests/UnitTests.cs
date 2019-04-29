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

        // Test write functionality
        //Write words to paper where character count = 0
        [TestMethod]
        public void InitialWordWritten()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How";
            writer.wordsToWrite(currentInput);
            writer.AddToPaper();

            Assert.AreEqual(currentInput, writer.items.paper);
        }

        // Write words to paper where character count > 0
        [TestMethod]
        public void AddingToPaper()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How";
            string expectedPaper = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";

            writer.wordsToWrite(currentInput);
            writer.AddToPaper();
            currentInput = " much wood would a woodchuck chuck if a woodchuck could chuck wood?";
            writer.wordsToWrite(currentInput);
            writer.AddToPaper();

            Assert.AreEqual(expectedPaper, writer.items.paper);
        }
    }
}
