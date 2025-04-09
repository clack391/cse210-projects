using System;

namespace EternalQuest
{
    // The SimpleGoal class represents a one-time accomplishment.
    // It inherits attributes from Goal and overrides methods as needed.
    public class SimpleGoal : Goal
    {
        public SimpleGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent(ref int totalScore)
        {
            if (!IsComplete)
            {
                totalScore += _points;
                IsComplete = true;
                Console.WriteLine($"Congratulations! You earned {_points} points!");
            }
            else
            {
                Console.WriteLine("This goal is already complete.");
            }
        }

        public override string GetStatus()
        {
            return IsComplete ? "Completed" : "Not Completed";
        }

        // This method is used during deserialization to mark the goal complete.
        public void MarkComplete()
        {
            IsComplete = true;
        }

        public override string GetStringRepresentation()
        {
            return $"SimpleGoal;{_name};{_description};{_points};{IsComplete}";
        }
    }
}
