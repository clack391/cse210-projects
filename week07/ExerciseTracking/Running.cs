using System;

namespace ExerciseTracking
{
    /// <summary>
    /// Derived class representing a running activity.
    /// Unique attribute _distance is stored only in this class.
    /// </summary>
    public class Running : Activity
    {
        // Private member variable for running-specific data.
        private double _distance; // Distance in miles.

        public Running(DateTime date, int minutes, double distance)
            : base(date, minutes)
        {
            _distance = distance;
        }

        public override double GetDistance()
        {
            return _distance;
        }

        public override double GetSpeed()
        {
            // Speed (mph) = (distance in miles / minutes) * 60.
            return (_distance / Minutes) * 60;
        }

        public override double GetPace()
        {
            // Pace (min per mile) = minutes / distance.
            return Minutes / _distance;
        }
    }
}
