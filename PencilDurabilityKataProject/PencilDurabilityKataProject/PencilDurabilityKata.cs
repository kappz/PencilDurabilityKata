using System;
using System.Collections.Generic;

namespace PencilDurabilityKataProject
{

    public class WriterActions
    {
        public WriterTools items; // Writer's pencil, paper

        public WriterActions()
        {
            items = new WriterTools();
        }

        public void ProcessInput(string words)
        {
            foreach (char character in words)
            {
                if (items.writersPencil.getDurability() > 0)
                {
                    items.paper.Add(character);
                    pencilDurability(character);
                }
                else
                {
                    items.paper.Add(' ');
                }
                
            }
        }

        public void pencilDurability(char currentCharacter)
        {
            if (Char.IsUpper(currentCharacter))
            {
                items.writersPencil.changeDurability(-2);
            }
            else if (currentCharacter == ' ' && currentCharacter == '\r' && currentCharacter == '\n')
            {
                items.writersPencil.changeDurability(0);
            }
            else if (currentCharacter != ' ' && currentCharacter != '\r' && currentCharacter != '\n')
            {
                items.writersPencil.changeDurability(-1);
            }
        }
    }

    public class WriterTools
    {
        public List<char> paper;
        public Pencil writersPencil;

        public WriterTools()
        {
            paper = new List<char>();
            writersPencil = new Pencil(1000);
        }
    }

    public class Pencil
    {
        int durability;

        public string charactersToWrite;

        public Pencil(int initialDurability)
        {
            durability = initialDurability;
            charactersToWrite = "";
        }

        public int getDurability()
        {
            return durability;
        }
        public void changeDurability(int num)
        {
            durability += num;
        }
    }
}
