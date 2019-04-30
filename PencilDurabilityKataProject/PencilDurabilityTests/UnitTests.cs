﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PencilDurabilityKataProject;

namespace PencilDurabilityKataTests
{
    [TestClass]
    public class UnitTests
    {
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
            string expectedOutput = "How much wood would a woodchuck chuck if a woodchuck could chuck wood?";

            writer.ProcessInput(currentInput);
            currentInput = " much wood would a woodchuck chuck if a woodchuck could chuck wood?";
            writer.ProcessInput(currentInput);

            Assert.AreEqual(expectedOutput, string.Join(null, writer.items.paper.ToArray()));
        }

        //Pencil prints white space when writing with a dull pencil.
        [TestMethod]
        public void PrintsWhiteSpaceWhenDull()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How much wood would";
            string expectedOutput = "How much wood w    ";

            writer.items.writersPencil.SetDurability(13);
            writer.ProcessInput(currentInput);

            Assert.AreEqual(expectedOutput, String.Join(null, writer.items.paper.ToArray()));
        }

        // Pencil Durability decreases by -2 when writing capital letter.
        [TestMethod]
        public void PencilDegradationByTwo()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "She sells sea shells";
        
            writer.ProcessInput(currentInput);

            Assert.AreEqual(982, writer.items.writersPencil.GetDurability());
        }

        // Pencil Durability decreases by -1 when writing lowercase letter.
        [TestMethod]
        public void PencilDegradationByOne()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "she sells sea shells down by the sea shore";

            writer.ProcessInput(currentInput);

            Assert.AreEqual(966, writer.items.writersPencil.GetDurability());
        }

        // Pencil Durability decreases by 0 when writing space or newline.
        [TestMethod]
        public void PencilDegradationByZero()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "shesellsseashells\r\n";

            writer.ProcessInput(currentInput);

            Assert.AreEqual(983, writer.items.writersPencil.GetDurability());
        }
    }
}
