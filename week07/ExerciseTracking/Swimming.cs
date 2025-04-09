using System;

namespace ExerciseTracking
{
    /// <summary>
    /// Derived class representing a swimming activity.
    /// Unique attribute _laps is stored only in this class.
    /// </summary>
    public class Swimming : Activity
    {
        // Private member variable for swimming-specific data.
        private int _laps;  // Number of laps swum.

        public Swimming(DateTime date, int minutes, int laps)
            : base(date, minutes)
        {
            _laps = laps;
        }

        public override double GetDistance()
        {
            // Each lap is 50 meters. Convert meters -> kilometers, then to miles using: 1 km = 0.62 miles.
            double kilometers = (_laps * 50.0) / 1000;
            double miles = kilometers * 0.62;
            return miles;
        }

        public override double GetSpeed()
        {
            // Speed (mph) = (distance in miles / minutes) * 60.
            return (GetDistance() / Minutes) * 60;
        }

        public override double GetPace()
        {
            // Pace (min per mile) = minutes / distance.
            double distance = GetDistance();
            return (distance != 0) ? Minutes / distance : 0;
        }
    }
}
