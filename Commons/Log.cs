using System;

namespace Commons
{
    public class Log
    {
        /// <summary>
        /// Log a warning message to the console.
        /// </summary>
        /// <param name="Message"></param>
        public static void Warn(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(DateTime.UtcNow.ToString("s") + " [WARNING] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Log an Error message to the console.
        /// </summary>
        /// <param name="Message"></param>
        public static void Error(string Message)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(DateTime.UtcNow.ToString("s") + " [ERROR] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Log a debug message to the console. If the bool CanSend is false, the message won't be sent.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="CanSend"></param>
        public static void Debug(string Message, bool CanSend = true)
        {
            if (CanSend)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(DateTime.UtcNow.ToString("s") + " [Debug] " + Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
        /// <summary>
        /// Log an info message to the console.
        /// </summary>
        /// <param name="Message"></param>
        public static void Info(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(DateTime.UtcNow.ToString("s") + " [Info] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Log a generic message, with the "[Message]" tag to the console.
        /// </summary>
        /// <param name="Message"></param>
        public static void Message(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(DateTime.UtcNow.ToString("s") + " [Message] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Log a generic message to the console.
        /// </summary>
        /// <param name="Message"></param>
        public static void Generic(string Message)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(DateTime.UtcNow.ToString("s") + " [Info] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
        /// <summary>
        /// Log a raw message to the console. Message is the message to log, InfoLevel is the info tag to prefix the message, and Color is the console color of the message.
        /// </summary>
        /// <param name="Message"></param>
        /// <param name="InfoLevel"></param>
        /// <param name="Color"></param>
        public static void Raw(string Message, string InfoLevel, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(DateTime.UtcNow.ToString("s") + $" [{InfoLevel}] " + Message);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}