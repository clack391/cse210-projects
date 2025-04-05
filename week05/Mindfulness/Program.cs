using System;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// The Program class drives the Mindfulness Program.
    /// It displays the menu, creates the proper activity instances, and logs each session.
    /// This version exceeds the core requirements by logging sessions and ensuring no reflection prompt repeats until all have been used.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // Create a logger to record each session to "session_log.txt"
            Logger logger = new Logger("session_log.txt");
            bool exit = false;
            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("Mindfulness Program");
                Console.WriteLine("===================");
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Quit");
                Console.Write("Select an option (1-4): ");
                string choice = Console.ReadLine();

                MindfulnessActivity activity = null;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity(logger);
                        break;
                    case "2":
                        activity = new ReflectionActivity(logger);
                        break;
                    case "3":
                        activity = new ListingActivity(logger);
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting the program. Have a mindful day!");
                        Thread.Sleep(2000);
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Thread.Sleep(2000);
                        continue;
                }
                activity.RunActivity();
            }
        }
    }
}
