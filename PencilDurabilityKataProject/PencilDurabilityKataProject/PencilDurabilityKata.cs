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

        // Add characters or words to paper
        public void ProcessInput(string words)
        {
            foreach (char character in words)
            {
                if (items.writersPencil.GetDurability() > 0)
                {
                    items.paper.Add(character);
                    items.writersPencil.UpdatePencilDurability(character);
                }
                else
                {
                    items.paper.Add(' ');
                }
                
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
        string charactersToWrite;

        public Pencil(int initialDurability)
        {
            durability = initialDurability;
            charactersToWrite = "";
        }

        public int GetDurability()
        {
            return durability;
        }

        public void SetDurability(int initialDurability)
        {
            durability = initialDurability;
        }

        // Computes point durability based off given point degrading values.
        public void UpdatePencilDurability(char currentCharacter)
        {
            if (Char.IsUpper(currentCharacter))
            {
                durability -= 2;
            }
            else if (currentCharacter == ' ' && currentCharacter == '\r' && currentCharacter == '\n')
            {
                durability -= 0;
            }
            else if (currentCharacter != ' ' && currentCharacter != '\r' && currentCharacter != '\n')
            {
                durability -= 1;
            }
        }
    }
}
