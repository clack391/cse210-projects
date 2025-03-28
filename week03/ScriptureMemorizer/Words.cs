using System;

namespace ScriptureMemorizer
{
    public class Word
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
}
