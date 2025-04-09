using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    /// <summary>
    /// Main program to create activities and display their summaries.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            // List to store activities.
            List<Activity> activities = new List<Activity>();

            // Create an instance of Running:
            // Date: 03 Nov 2022, Duration: 30 minutes, Distance: 3.0 miles.
            Activity runningActivity = new Running(new DateTime(2022, 11, 03), 30, 3.0);
            activities.Add(runningActivity);

            // Create an instance of Cycling:
            // Date: 05 Nov 2022, Duration: 45 minutes, Speed: 12.0 mph.
            Activity cyclingActivity = new Cycling(new DateTime(2022, 11, 05), 45, 12.0);
            activities.Add(cyclingActivity);

            // Create an instance of Swimming:
            // Date: 07 Nov 2022, Duration: 30 minutes, Laps: 20.
            Activity swimmingActivity = new Swimming(new DateTime(2022, 11, 07), 30, 20);
            activities.Add(swimmingActivity);

            // Iterate through the activities list and display each summary.
            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
}
