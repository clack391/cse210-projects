using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// The ListingActivity class inherits from MindfulnessActivity and implements the listing exercise.
    /// It displays a random prompt, gives the user time to list responses, and then displays the count.
    /// </summary>
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts;

        public ListingActivity(Logger logger)
            : base("Listing", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.", logger)
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }

        public override void RunActivity()
        {
            DisplayStartMessage();

            // Select and display a random listing prompt.
            Random rand = new Random();
            string selectedPrompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine("\nList as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {selectedPrompt} ---");

            Console.WriteLine("You may begin in:");
            Countdown(5);

            List<string> responses = new List<string>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            Console.WriteLine("\nStart listing your items. Press Enter after each one:");
            // Capture user input until the duration expires.
            while (DateTime.Now < endTime)
            {
                if (Console.KeyAvailable)
                {
                    string response = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(response))
                    {
                        responses.Add(response);
                    }
                }
            }

            Console.WriteLine($"\nYou listed {responses.Count} items.");
            DisplayEndMessage();
        }

        // Displays a countdown timer before the listing begins.
        private void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}
