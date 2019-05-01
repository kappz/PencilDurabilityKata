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
                    if (character == ' ')
                    {
                        paper.Add(' ');
                    }
                    else
                    {
                        paper.Add(character);
                        pencil.DecreasePencilDurability(character);
                    }
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

        // Writer edits.
        public void Edit(string editText)
        {
            int matchIndex = -1;
            int textLength = editText.Length;
            string currentPaper = string.Join(null, paper.ToArray());

            matchIndex = FindEditIndex(currentPaper);
            if (matchIndex != -1)
            {
                for (int i = 0; i < textLength; ++i)
                {
                    if (pencil.GetCurrentDurability() > 0)
                    {
                        if (matchIndex < paper.Count)
                        {
                            if (paper[matchIndex] == ' ')
                            {
                                paper[matchIndex] = editText[i];
                                pencil.DecreasePencilDurability(editText[i]);
                                ++matchIndex;
                            }
                            else
                            {
                                paper[matchIndex] = '@';
                                ++matchIndex;
                            }
                        }
                        else
                        {
                            paper.Add(editText[i]);
                            pencil.DecreasePencilDurability(editText[i]);
                        }
                    }
                }
            }
        }

        public int FindEditIndex(string editText)
        {
            int index = -1;
            int currentIndex = editText.Length - 1;
            int count = 0;
            
            while (count <= 1 && currentIndex >= 0)
            {
                if (editText[currentIndex] == ' ')
                {
                    ++count;
                }
                else
                {
                    count = 0;
                }
                --currentIndex;
            }

            if (count > 1)
            {
                while (editText[currentIndex] == ' ')
                {
                    --currentIndex;
                }
                currentIndex += 2;
            }
            index = currentIndex;
            return index;
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
