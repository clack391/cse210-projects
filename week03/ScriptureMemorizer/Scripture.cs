using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private Reference reference;
        private List<Word> words;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            words = new List<Word>();
            foreach (var word in text.Split(' '))
            {
                words.Add(new Word(word));
            }
        }

        // Displays the scripture reference and the current state of the text.
        public void Display()
        {
            Console.WriteLine(reference.ToString());
            foreach (var word in words)
            {
                Console.Write(word.GetDisplay() + " ");
            }
            Console.WriteLine("\n");
        }

        // Returns true if every word is hidden.
        public bool AllWordsHidden()
        {
            return words.All(w => w.IsHidden());
        }

        // Hides up to 'count' random words that are not already hidden.
        public void HideWords(int count)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < words.Count; i++)
            {
                if (!words[i].IsHidden())
                {
                    indices.Add(i);
                }
            }

            if (indices.Count == 0)
                return;

            Random rand = new Random();
            int wordsToHide = Math.Min(count, indices.Count);
            for (int i = 0; i < wordsToHide; i++)
            {
                int randomIndex = rand.Next(indices.Count);
                int wordIndex = indices[randomIndex];
                words[wordIndex].Hide();
                indices.RemoveAt(randomIndex);
            }
        }
    }
}
