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
        //Write words to paper where character count = 0.
        [TestMethod]
        public void InitialWordWritten()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How";
            writer.ProcessInput(currentInput);

            Assert.AreEqual(currentInput, string.Join(null, writer.paper.ToArray()));
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

            Assert.AreEqual(expectedOutput, string.Join(null, writer.paper.ToArray()));
        }

        //Pencil prints white space when writing with a dull pencil.
        [TestMethod]
        public void PrintsWhiteSpaceWhenDull()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "How much wood would";
            string expectedOutput = "How much wood w    ";

            writer.pencil.SetDurability(13);
            writer.ProcessInput(currentInput);

            Assert.AreEqual(expectedOutput, String.Join(null, writer.paper.ToArray()));
        }

        // Pencil Durability decreases by -2 when writing capital letter.
        [TestMethod]
        public void PencilDegradationByTwo()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "She sells sea shells";

            writer.ProcessInput(currentInput);

            Assert.AreEqual(982, writer.pencil.GetCurrentDurability());
        }

        // Pencil Durability decreases by -1 when writing lowercase letter.
        [TestMethod]
        public void PencilDegradationByOne()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "she sells sea shells down by the sea shore";

            writer.ProcessInput(currentInput);

            Assert.AreEqual(966, writer.pencil.GetCurrentDurability());
        }

        // Pencil Durability decreases by 0 when writing space or newline.
        [TestMethod]
        public void PencilDegradationByZero()
        {
            WriterActions writer = new WriterActions();
            string currentInput = "shesellsseashells\r\n";

            writer.ProcessInput(currentInput);

            Assert.AreEqual(983, writer.pencil.GetCurrentDurability());
        }

        // Writes spaces when pencil length is zero.
        [TestMethod]
        public void SpacesWhenLengthIsZero()
        {
            WriterActions writer = new WriterActions();

            writer.pencil.SetLength(1);
            writer.pencil.SetDurability(0);
            writer.SharpenPencil();
            writer.ProcessInput("Hello world");

            Assert.AreEqual("           ", string.Join(null, writer.paper.ToArray()));

        }

        // Writer sharpens pencil
        [TestMethod]
        public void WriterSharpensPencil()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("Hello world");
            writer.SharpenPencil();

            Assert.AreEqual(1000, writer.pencil.GetCurrentDurability());
        }

        // Pencil Length Value Decreases after SharpenPencil.
        [TestMethod]
        public void PencilLengthUpdated()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("Hello world");
            writer.SharpenPencil();

            Assert.AreEqual(19, writer.pencil.GetLength());
        }

        // Erases the last occurance of text.
        [TestMethod]
        public void EraseLastOccuranceOfText()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.Erase("much wood would.");

            Assert.AreEqual("how                 ", string.Join(null, writer.paper.ToArray()));
        }

       // Erases text in middle of page.
       [TestMethod]
       public void EraseTextInMiddlePage()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.Erase("much w");

            Assert.AreEqual("how       ood would.", string.Join(null, writer.paper.ToArray()));
        }

        // Erases the empty string.
        [TestMethod]
        public void EraseNoText()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.Erase("");

            Assert.AreEqual("how much wood would.", string.Join(null, writer.paper.ToArray()));

        }
        // Eraser durability decreases.
        [TestMethod]
        public void EraserDegrades()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.Erase("much w");

            Assert.AreEqual(1994, writer.pencil.GetCurrentEraserDurability());
        }

        // Eraser durability when writer erases the empty string.
        [TestMethod]
        public void EraserDurabilityWhenEmptyStringErased()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.Erase("");

            Assert.AreEqual(2000, writer.pencil.GetCurrentEraserDurability());
        }

        // Attempts Erase when eraser durability is zero.
        [TestMethod]
        public void EraseWhenEraserDurabilityZero()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.pencil.DecreaseEraserDurability(2000); // Degrade erase to zero
            writer.Erase("how ");

            Assert.AreEqual("how much wood would.", string.Join(null, writer.paper.ToArray()));
        }

        // Eraser fully degrades while erasing.
        [TestMethod]
        public void EraserDegradesWhileErasing()
        {
            WriterActions writer = new WriterActions();

            writer.ProcessInput("how much wood would.");
            writer.pencil.DecreaseEraserDurability(1995); // Degrade erase to zero
            writer.Erase("how mu");

            Assert.AreEqual("h     ch wood would.", string.Join(null, writer.paper.ToArray()));
        }
    }
}
