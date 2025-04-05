using System;
using System.IO;

namespace MindfulnessProgram
{
    /// <summary>
    /// The Logger class is responsible for saving session logs to a file.
    /// Each time an activity is completed, a log entry is appended to the log file.
    /// This exceeds the core requirements by tracking user activity over time.
    /// </summary>
    public class Logger
    {
        private string _logFilePath;

        public Logger(string logFilePath)
        {
            _logFilePath = logFilePath;
            // Initialize the log file if it does not exist.
            if (!File.Exists(_logFilePath))
            {
                File.WriteAllText(_logFilePath, "Mindfulness Program Session Log\n------------------------------\n");
            }
        }

        // Logs a completed session with the activity name and duration.
        public void LogSession(string activityName, int duration)
        {
            string logEntry = $"{DateTime.Now}: Completed {activityName} Activity for {duration} seconds.\n";
            File.AppendAllText(_logFilePath, logEntry);
        }
    }
}
