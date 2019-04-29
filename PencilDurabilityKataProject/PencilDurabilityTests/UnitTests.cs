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

        // Test write functionality.
        //Write words to paper where character count = 0.
        [TestMethod]
        public void InitialWordWritten()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How";
            writer.ProcessInput(currentInput);
        
            Assert.AreEqual(currentInput, string.Join(null, writer.items.paper.ToArray()));
        }

        // Two writes to paper test.
        [TestMethod]
        public void AddingToPaper()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How";
            string expectedPaper = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";

            writer.ProcessInput(currentInput);
            currentInput = " much wood would a woodchuck chuck if a woodchuck could chuck wood?";
            writer.ProcessInput(currentInput);

            Assert.AreEqual(expectedPaper, string.Join(null, writer.items.paper.ToArray()));
        }

        // Pencil Durability Changes by -2 for capital letter.
        [TestMethod]
        public void PencilDegradation()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "She sells sea shells";
        
            writer.ProcessInput(currentInput);

            Assert.AreEqual(982, writer.items.writersPencil.getDurability());
        }
    }
}
