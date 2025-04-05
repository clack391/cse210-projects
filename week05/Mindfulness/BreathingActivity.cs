using System;
using System.Threading;

namespace MindfulnessProgram
{
    /// <summary>
    /// The BreathingActivity class inherits from MindfulnessActivity and implements the breathing exercise.
    /// It alternates between "Breathe in..." and "Breathe out..." messages with a countdown.
    /// </summary>
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity(Logger logger)
            : base("Breathing", "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.", logger)
        {
        }

        public override void RunActivity()
        {
            DisplayStartMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(_duration);

            // Continue alternating phases until the duration expires.
            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in... ");
                Countdown(4);
                if (DateTime.Now >= endTime) break;
                Console.Write("Breathe out... ");
                Countdown(6);
            }

            DisplayEndMessage();
        }

        // Displays a countdown timer for the specified number of seconds.
        private void Countdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            Console.WriteLine();
        }
    }
}
