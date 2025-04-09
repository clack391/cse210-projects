using System;
using System.Globalization;

namespace ExerciseTracking
{
    /// <summary>
    /// Base abstract class for all activities.
    /// Contains shared attributes for the activity date and duration.
    /// </summary>
    public abstract class Activity
    {
        // Private member variables for encapsulation.
        private DateTime _date;
        private int _minutes;  // Duration of the activity in minutes.

        public Activity(DateTime date, int minutes)
        {
            _date = date;
            _minutes = minutes;
        }

        // Read-only properties.
        public DateTime Date => _date;
        public int Minutes => _minutes;

        // Abstract methods to be overridden by derived classes.
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();

        // Virtual method to get a summary string for the activity.
        public virtual string GetSummary()
        {
            string dateString = Date.ToString("dd MMM yyyy", CultureInfo.InvariantCulture);
            string activityType = this.GetType().Name;
            double distance = GetDistance();
            double speed = GetSpeed();
            double pace = GetPace();
            return $"{dateString} {activityType} ({Minutes} min)- Distance: {distance:F1} miles, Speed: {speed:F1} mph, Pace: {pace:F1} min per mile";
        }
    }
}
