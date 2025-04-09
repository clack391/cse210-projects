using System;

namespace EternalQuest
{
    // The ChecklistGoal class represents a goal that must be recorded a specific number of times.
    // Points are awarded with each record, and a bonus is given on final completion.
    public class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonus;

        public ChecklistGoal(string name, string description, int points, int targetCount, int bonus)
            : base(name, description, points)
        {
            _targetCount = targetCount;
            _currentCount = 0;
            _bonus = bonus;
        }

        public override void RecordEvent(ref int totalScore)
        {
            if (!IsComplete)
            {
                _currentCount++;
                totalScore += _points;
                Console.WriteLine($"You earned {_points} points for this step! ({_currentCount}/{_targetCount})");
                if (_currentCount >= _targetCount)
                {
                    totalScore += _bonus;
                    IsComplete = true;
                    Console.WriteLine($"Congratulations! You've completed the checklist goal and earned a bonus of {_bonus} points!");
                }
            }
            else
            {
                Console.WriteLine("This checklist goal has already been completed.");
            }
        }

        public override string GetStatus()
        {
            return IsComplete ? "Completed" : $"In Progress ({_currentCount}/{_targetCount})";
        }

        public void SetCurrentCount(int count)
        {
            _currentCount = count;
            if (_currentCount >= _targetCount)
            {
                IsComplete = true;
            }
        }

        public override string GetDisplayString()
        {
            string checkbox = IsComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_description}) -- Progress: {_currentCount}/{_targetCount}";
        }

        public override string GetStringRepresentation()
        {
            return $"ChecklistGoal;{_name};{_description};{_points};{_targetCount};{_currentCount};{_bonus}";
        }
    }
}
