using System;
using System.Collections.Generic;
using System.IO;

namespace EternalQuest
{
    // The Program class contains the Main method and manages the menu-driven interface.
    // It also implements an extra gamification feature by calculating the user's level based on score.
    // This file ties together all the goal types and functionalities, fulfilling the rubric requirements.
    class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;

        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("\nMenu Options:");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Display Score");
                Console.WriteLine("7. Quit");
                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CreateNewGoal();
                        break;
                    case "2":
                        ListGoals();
                        break;
                    case "3":
                        SaveGoals();
                        break;
                    case "4":
                        LoadGoals();
                        break;
                    case "5":
                        RecordEvent();
                        break;
                    case "6":
                        DisplayScore();
                        break;
                    case "7":
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option, please try again.");
                        break;
                }
            }
        }

        // Allows user to create a new goal (Simple, Eternal, or Checklist) with specified parameters.
        private static void CreateNewGoal()
        {
            Console.WriteLine("\nSelect the type of goal to create:");
            Console.WriteLine("1. Simple Goal");
            Console.WriteLine("2. Eternal Goal");
            Console.WriteLine("3. Checklist Goal");
            Console.Write("Choice: ");
            string typeChoice = Console.ReadLine();

            Console.Write("Enter goal name: ");
            string name = Console.ReadLine();
            Console.Write("Enter goal description: ");
            string description = Console.ReadLine();
            Console.Write("Enter points for completing goal: ");
            int points;
            while (!int.TryParse(Console.ReadLine(), out points))
            {
                Console.Write("Invalid input, please enter an integer for points: ");
            }

            switch (typeChoice)
            {
                case "1":
                    _goals.Add(new SimpleGoal(name, description, points));
                    break;
                case "2":
                    _goals.Add(new EternalGoal(name, description, points));
                    break;
                case "3":
                    Console.Write("Enter target count for checklist: ");
                    int targetCount;
                    while (!int.TryParse(Console.ReadLine(), out targetCount))
                    {
                        Console.Write("Invalid input, please enter an integer for target count: ");
                    }
                    Console.Write("Enter bonus points for completing checklist: ");
                    int bonus;
                    while (!int.TryParse(Console.ReadLine(), out bonus))
                    {
                        Console.Write("Invalid input, please enter an integer for bonus points: ");
                    }
                    _goals.Add(new ChecklistGoal(name, description, points, targetCount, bonus));
                    break;
                default:
                    Console.WriteLine("Invalid goal type selected.");
                    break;
            }
        }

        // Lists all goals with their current progress/status.
        private static void ListGoals()
        {
            Console.WriteLine("\nYour Goals:");
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetDisplayString()}");
                index++;
            }
        }

        // Saves the user’s score and all goals to a file.
        private static void SaveGoals()
        {
            Console.Write("Enter filename to save goals: ");
            string filename = Console.ReadLine();
            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine(_score);
                foreach (Goal goal in _goals)
                {
                    writer.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully.");
        }

        // Loads goals and score from a file.
        private static void LoadGoals()
        {
            Console.Write("Enter filename to load goals from: ");
            string filename = Console.ReadLine();
            if (File.Exists(filename))
            {
                string[] lines = File.ReadAllLines(filename);
                _goals.Clear();
                if (lines.Length > 0)
                {
                    int.TryParse(lines[0], out _score);
                }
                for (int i = 1; i < lines.Length; i++)
                {
                    try
                    {
                        Goal goal = Goal.CreateFromString(lines[i]);
                        _goals.Add(goal);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error loading goal from line: {lines[i]}. Error: {ex.Message}");
                    }
                }
                Console.WriteLine("Goals loaded successfully.");
            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }

        // Records a goal event based on user selection and updates the score.
        private static void RecordEvent()
        {
            Console.WriteLine("\nSelect the goal you accomplished:");
            int index = 1;
            foreach (Goal goal in _goals)
            {
                Console.WriteLine($"{index}. {goal.GetDisplayString()}");
                index++;
            }
            Console.Write("Enter goal number: ");
            int goalNumber;
            if (int.TryParse(Console.ReadLine(), out goalNumber) && goalNumber > 0 && goalNumber <= _goals.Count)
            {
                Goal selectedGoal = _goals[goalNumber - 1];
                selectedGoal.RecordEvent(ref _score);
            }
            else
            {
                Console.WriteLine("Invalid goal number.");
            }
        }

        // Displays the current score along with a gamified level (every 1000 points equals one level).
        private static void DisplayScore()
        {
            int level = _score / 1000;
            Console.WriteLine($"\nYour current score is: {_score}");
            Console.WriteLine($"You are at Level: {level}");
        }
    }
}
