using System;

namespace EternalQuest
{
    // The abstract Goal class defines attributes and methods shared among all goals.
    // It ensures that only goal-related items are included in this class.
    public abstract class Goal
    {
        protected string _name;
        protected string _description;
        protected int _points;
        public bool IsComplete { get; protected set; }

        public Goal(string name, string description, int points)
        {
            _name = name;
            _description = description;
            _points = points;
            IsComplete = false;
        }

        // Each derived class must implement how an event is recorded.
        public abstract void RecordEvent(ref int totalScore);

        // Return a string representing the status (e.g., Completed or In Progress).
        public abstract string GetStatus();

        // Return a string representation suitable for saving to a file.
        public abstract string GetStringRepresentation();

        // Virtual method returning a display string.
        public virtual string GetDisplayString()
        {
            string checkbox = IsComplete ? "[X]" : "[ ]";
            return $"{checkbox} {_name} ({_description})";
        }

        // Factory method to re-create goals from a saved string.
        public static Goal CreateFromString(string data)
        {
            // Expected format:
            // SimpleGoal;Name;Description;Points;IsComplete
            // EternalGoal;Name;Description;Points
            // ChecklistGoal;Name;Description;Points;TargetCount;CurrentCount;Bonus
            string[] parts = data.Split(";");
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                bool isComplete = bool.Parse(parts[4]);
                SimpleGoal goal = new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]));
                if (isComplete)
                    goal.MarkComplete();
                return goal;
            }
            else if (type == "EternalGoal")
            {
                return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]));
            }
            else if (type == "ChecklistGoal")
            {
                int targetCount = int.Parse(parts[4]);
                int currentCount = int.Parse(parts[5]);
                int bonus = int.Parse(parts[6]);
                ChecklistGoal goal = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), targetCount, bonus);
                goal.SetCurrentCount(currentCount);
                return goal;
            }
            else
            {
                throw new Exception("Invalid goal type in saved data.");
            }
        }
    }
}
