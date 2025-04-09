using System;

namespace ExerciseTracking
{
    /// <summary>
    /// Derived class representing a cycling activity.
    /// Unique attribute _speed is stored only in this class.
    /// </summary>
    public class Cycling : Activity
    {
        // Private member variable for cycling-specific data.
        private double _speed;  // Speed in mph.

        public Cycling(DateTime date, int minutes, double speed)
            : base(date, minutes)
        {
            _speed = speed;
        }

        public override double GetDistance()
        {
            // Distance = speed * (minutes/60)
            return _speed * (Minutes / 60.0);
        }

        public override double GetSpeed()
        {
            return _speed;
        }

        public override double GetPace()
        {
            // Pace = minutes per mile = minutes / distance.
            double distance = GetDistance();
            return (distance != 0) ? Minutes / distance : 0;
        }
    }
}
