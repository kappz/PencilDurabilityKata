using System;
using System.Collections.Generic;

namespace PencilDurabilityKataProject
{

    public class WriterActions
    {
        public Pencil pencil;
        public List<char> paper;

        public WriterActions()
        {
            paper = new List<char>();
            pencil = new Pencil(1000, 2000, 20);
        }

        // Add characters or words to paper
        public void ProcessInput(string words)
        {
            foreach (char character in words)
            {
                if (pencil.GetCurrentDurability() > 0)
                {
                    paper.Add(character);
                    pencil.DecreasePencilDurability(character);
                }
                else
                {
                   paper.Add(' ');
                }
                
            }
        }

        // Sharpen Pencil back to full durability.
        public void SharpenPencil()
        {
            pencil.SetDurability(pencil.GetInitialDurability());
            pencil.DecreaseLength();
        }

        // Writer erases
        public void Erase(string eraseText)
        {
            int matchIndex = -1;
            int textLength = eraseText.Length;
            string currentPaper = string.Join(null, paper.ToArray());

            matchIndex = currentPaper.LastIndexOf(eraseText);
            if (matchIndex != -1)
            {
                for (int i = matchIndex + (textLength -1); i >= matchIndex; --i)
                {
                    if (pencil.GetCurrentEraserDurability() > 0)
                    {
                        paper[i] = ' ';
                        pencil.DecreaseEraserDurability(1);
                    }
                }
            }
        }
    }
  
    public class Pencil
    {
        int initialDurability;
        int currentDurability;
        int initialEraserDurability;
        int currentEraserDurability;
        int length;


        public Pencil(int durability, int eraserDurability, int l)
        {
            length = l;
            initialDurability = durability;
            currentDurability = durability;
            initialEraserDurability = eraserDurability;
            currentEraserDurability = eraserDurability;
        }

        public int GetInitialDurability()
        {
            return initialDurability;
        }

        public int GetCurrentDurability()
        {
            return currentDurability;
        }

        public void SetDurability(int durability)
        {
            initialDurability = durability;
            currentDurability = durability;
        }

        public int GetLength()
        {
            return length;
        }

        public void SetLength(int l)
        {
            length = l;
        }

        public void DecreaseLength()
        {
            --length;
        }

        public int GetInitialEraserDurability()
        {
            return initialEraserDurability;
        }

        public int GetCurrentEraserDurability()
        {
            return currentEraserDurability;
        }

        public void DecreaseEraserDurability(int amount)
        {
            currentEraserDurability -= amount;
        }

        // Computes point durability based off given point degrading values.
        public void DecreasePencilDurability(char currentCharacter)
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
