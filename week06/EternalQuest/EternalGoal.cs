using System;

namespace EternalQuest
{
    // The EternalGoal class represents a goal that is never "completed".
    // It awards points every time the event is recorded.
    public class EternalGoal : Goal
    {
        public EternalGoal(string name, string description, int points)
            : base(name, description, points)
        {
        }

        public override void RecordEvent(ref int totalScore)
        {
            totalScore += _points;
            Console.WriteLine($"Great job! You earned {_points} points!");
        }

        public override string GetStatus()
        {
            return "Eternal Goal (Not Completed)";
        }

        public override string GetDisplayString()
        {
            return $"{_name} ({_description}) - {GetStatus()}";
        }

        public override string GetStringRepresentation()
        {
            return $"EternalGoal;{_name};{_description};{_points}";
        }
    }
}
