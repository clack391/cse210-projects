using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    // Represents a single word from the scripture.
    class Word
    {
        private string originalWord;
        private bool hidden;

        public Word(string word)
        {
            originalWord = word;
            hidden = false;
        }

        // Returns the word or underscores if hidden.
        public string GetDisplay()
        {
            return hidden ? new string('_', originalWord.Length) : originalWord;
        }

        // Hides the word.
        public void Hide()
        {
            hidden = true;
        }

        public bool IsHidden()
        {
            return hidden;
        }
    }

    // Represents the scripture reference.
    class Reference
    {
        private string book;
        private int chapter;
        private int verseStart;
        private int verseEnd;

        // Constructor for a single verse.
        public Reference(string book, int chapter, int verse)
        {
            this.book = book;
            this.chapter = chapter;
            this.verseStart = verse;
            this.verseEnd = verse;
        }

        // Constructor for a range of verses.
        public Reference(string book, int chapter, int verseStart, int verseEnd)
        {
            this.book = book;
            this.chapter = chapter;
            this.verseStart = verseStart;
            this.verseEnd = verseEnd;
        }

        public override string ToString()
        {
            if (verseStart == verseEnd)
            {
                return $"{book} {chapter}:{verseStart}";
            }
            else
            {
                return $"{book} {chapter}:{verseStart}-{verseEnd}";
            }
        }
    }

    // Represents the scripture, containing a reference and its text.
    class Scripture
    {
        private Reference reference;
        private List<Word> words;

        public Scripture(Reference reference, string text)
        {
            this.reference = reference;
            // Split text into words and store as Word objects.
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
            // Find indices of words that are not yet hidden.
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

    // Main program.
    class Program
    {
        static void Main(string[] args)
        {
            // Scripture example:
            // "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            Scripture scripture = new Scripture(reference, text);

            // Main loop: display the scripture and hide more words until all words are hidden or the user quits.
            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words have been hidden. Good job!");
                    break;
                }

                Console.WriteLine("Press ENTER to hide words, or type 'quit' to exit:");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                // Hide 3 random words per iteration.
                scripture.HideWords(3);
            }
        }
    }
}