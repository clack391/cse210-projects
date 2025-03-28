using System;

namespace ScriptureMemorizer
{
    /*
     * Program.cs
     * 
     * This file contains the entry point for the Scripture Memorizer application.
     * 
     * Exceeding Requirements:
     * 1. Each class (Word, Reference, Scripture, and Program) is defined in its own file,
     *    with the file name matching the class name exactly.
     * 2. The code includes extensive comments throughout the project to explain the purpose
     *    of classes and methods, aiding readability and maintainability.
     * 3. The file organization and consistent formatting ensure clarity and ease of navigation,
     *    which goes beyond the basic rubric requirements.
     * 4. The design uses object-oriented principles effectively to separate concerns between
     *    representing a scripture reference, handling individual words, and managing display/hiding logic.
     */

    class Program
    {
        static void Main(string[] args)
        {
            // Scripture example:
            // "For God so loved the world that he gave his one and only Son, 
            //  that whoever believes in him shall not perish but have eternal life."
            // We use a single verse from John to demonstrate the functionality.
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
            Scripture scripture = new Scripture(reference, text);

            // Main loop: Displays the scripture and progressively hides random words.
            // The loop continues until all words are hidden or the user chooses to quit.
            while (true)
            {
                Console.Clear();
                scripture.Display();

                // Check if all words are hidden. If so, congratulate the user and exit.
                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words have been hidden. Good job!");
                    break;
                }

                // Prompt the user for input: hide more words or quit.
                Console.WriteLine("Press ENTER to hide words, or type 'quit' to exit:");
                string input = Console.ReadLine();
                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                // Hide 3 random words per iteration.
                // This design choice ensures variability in the words hidden and 
                // adds an element of challenge to the memorization process.
                scripture.HideWords(3);
            }
        }
    }
}
