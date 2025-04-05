using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// The ReflectionActivity class inherits from MindfulnessActivity and implements the reflection exercise.
    /// It randomly selects a prompt and then displays a series of reflective questions.
    /// This version ensures all questions are used before any repeats occur.
    /// </summary>
    public class ReflectionActivity : MindfulnessActivity
    {
        private List<string> _prompts;
        private List<string> _questions;
        private List<string> _usedQuestions; // Tracks used questions for non-repetition

        public ReflectionActivity(Logger logger)
            : base("Reflection", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.", logger)
        {
            _prompts = new List<string>
            {
                "Think of a time when you stood up for someone else.",
                "Think of a time when you did something really difficult.",
                "Think of a time when you helped someone in need.",
                "Think of a time when you did something truly selfless."
            };

            _questions = new List<string>
            {
                "Why was this experience meaningful to you?",
                "Have you ever done anything like this before?",
                "How did you get started?",
                "How did you feel when it was complete?",
                "What made this time different than other times when you were not as successful?",
                "What is your favorite thing about this experience?",
                "What could you learn from this experience that applies to other situations?",
                "What did you learn about yourself through this experience?",
                "How can you keep this experience in mind in the future?"
            };
            _usedQuestions = new List<string>();
        }

        public override void RunActivity()
        {
            DisplayStartMessage();

            // Select and display a random reflection prompt.
            Random rand = new Random();
            string selectedPrompt = _prompts[rand.Next(_prompts.Count)];
            Console.WriteLine("\nConsider the following prompt:");
            Console.WriteLine($"--- {selectedPrompt} ---");
            Console.WriteLine("\nWhen you have something in mind, press Enter to continue.");
            Console.ReadLine();

            Console.WriteLine("Now ponder on each of the following questions as they relate to this experience:");
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            // Display questions repeatedly until the allotted time expires.
            while (DateTime.Now < endTime)
            {
                string question = GetRandomQuestion();
                Console.Write($"\n> {question}");
                PauseWithAnimation(5);
            }

            DisplayEndMessage();
        }

        // Retrieves a random question ensuring all questions are used before repeating.
        private string GetRandomQuestion()
        {
            Random rand = new Random();
            if (_usedQuestions.Count >= _questions.Count)
            {
                _usedQuestions.Clear();
            }
            string question;
            do
            {
                question = _questions[rand.Next(_questions.Count)];
            } while (_usedQuestions.Contains(question));
            _usedQuestions.Add(question);
            return question;
        }
    }
}
