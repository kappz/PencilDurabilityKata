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
                if (items.writersPencil.GetCurrentDurability() > 0)
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

        //Sharpen Pencil back to full durability.
        public void SharpenPencil()
        {
            items.writersPencil.SetDurability(items.writersPencil.GetInitialDurability());
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
        int initialDurability;
        int currentDurability;
        string charactersToWrite;

        public Pencil(int durability)
        {
            initialDurability = durability;
            currentDurability = initialDurability;
            charactersToWrite = "";
        }

        public int GetCurrentDurability()
        {
            return currentDurability;
        }

        public int GetInitialDurability()
        {
            return initialDurability;
        }

        public void SetDurability(int durability)
        {
            initialDurability = durability;
            currentDurability = durability;
        }

        // Computes point durability based off given point degrading values.
        public void UpdatePencilDurability(char currentCharacter)
        {
            if (Char.IsUpper(currentCharacter))
            {
                currentDurability -= 2;
            }
            else if (currentCharacter == ' ' && currentCharacter == '\r' && currentCharacter == '\n')
            {
                currentDurability -= 0;
            }
            else if (currentCharacter != ' ' && currentCharacter != '\r' && currentCharacter != '\n')
            {
                currentDurability -= 1;
            }
        }
    }
}
