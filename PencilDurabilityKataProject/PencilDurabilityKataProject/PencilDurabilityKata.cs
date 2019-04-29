using System;
using System.Collections.Generic;

namespace PencilDurabilityKataProject
{
    public class WriterTools
    {
        public string paper;
        public Pencil writersPencil;
   
        public WriterTools()
        {
            paper = "";
            writersPencil = new Pencil();
        }

    }

    public class WriterActions
    {
        public WriterTools items; // Writer's pencil, paper

        public WriterActions()
        {
            items = new WriterTools();
        }
    }

    public class Pencil
    {
        public string charactersToWrite;

        public Pencil()
        {
            charactersToWrite = "";
        }
    }
}
