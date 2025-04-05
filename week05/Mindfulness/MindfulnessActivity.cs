using System;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// The MindfulnessActivity class defines the shared attributes and behaviors for all activities.
    /// It uses encapsulation to hide member variables (_activityName, _description, _duration, _logger)
    /// and provides common methods for starting, ending, and pausing with animations.
    /// </summary>
    public abstract class MindfulnessActivity
    {
        // Member variables (using underscoreCamelCase for private/protected members).
        protected string _activityName;
        protected string _description;
        protected int _duration; // in seconds
        protected Logger _logger; // Logger instance for session logging

        public MindfulnessActivity(string activityName, string description, Logger logger)
        {
            _activityName = activityName;
            _description = description;
            _logger = logger;
        }

        // Asks the user to set the duration for the activity.
        protected void SetDuration()
        {
            Console.Write("Enter duration in seconds: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int duration))
            {
                _duration = duration;
            }
            else
            {
                Console.WriteLine("Invalid input. Defaulting to 30 seconds.");
                _duration = 30;
            }
        }

        // Displays a common starting message and prepares the user.
        public virtual void DisplayStartMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {_activityName} Activity.");
            Console.WriteLine(_description);
            SetDuration();
            Console.WriteLine("Get ready...");
            PauseWithAnimation(3);
        }

        // Displays a common ending message and logs the session.
        public virtual void DisplayEndMessage()
        {
            Console.WriteLine("\nGood job!");
            PauseWithAnimation(3);
            Console.WriteLine($"\nYou have completed the {_activityName} Activity for {_duration} seconds.");
            PauseWithAnimation(3);
            // Log the completed session.
            _logger.LogSession(_activityName, _duration);
        }

        // Displays a spinner animation using backspaces to create a dynamic effect.
        protected void PauseWithAnimation(int seconds)
        {
            int spinnerDelay = 250;
            int totalIterations = (seconds * 1000) / spinnerDelay;
            char[] spinner = { '|', '/', '-', '\\' };
            for (int i = 0; i < totalIterations; i++)
            {
                Console.Write(spinner[i % spinner.Length]);
                Thread.Sleep(spinnerDelay);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }

        // Each derived class must implement its own RunActivity method.
        public abstract void RunActivity();
    }
}
