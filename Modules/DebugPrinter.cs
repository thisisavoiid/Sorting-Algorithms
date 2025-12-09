using System.Reflection.Metadata;

namespace Sortieralgorithmen
{
    internal class DebugPrinter
    {

        /// <summary>
        /// Holds the values about how to format a debug message.
        /// </summary>
        struct ConsoleFormat
        {
            public ConsoleColor FgColor;
            public ConsoleColor BgColor;
            public string Prefix;
        }

        /// <summary>
        /// Contains the different debug levels.
        /// </summary>
        internal enum DebugLevel
        {
            Info,
            Warning,
            Error
        }

        /// <summary>
        /// Contains the combined debug message formats including prefixes.
        /// </summary>
        static readonly Dictionary<DebugLevel, ConsoleFormat> DebugFormat = new Dictionary<DebugLevel, ConsoleFormat>()
        {
            {DebugLevel.Info, new ConsoleFormat{FgColor=ConsoleColor.White, BgColor=ConsoleColor.Black, Prefix="INFO" }},
            {DebugLevel.Warning, new ConsoleFormat{FgColor=ConsoleColor.Yellow, BgColor=ConsoleColor.Black, Prefix="WARNING" }},
            {DebugLevel.Error, new ConsoleFormat{FgColor=ConsoleColor.Red, BgColor=ConsoleColor.Black, Prefix="ERROR" }}
        };

        /// <summary>
        /// Prints a debug message.
        /// </summary>
        /// <param name="message">
        /// Message to print.
        /// </param>
        /// <param name="level">
        /// Debug level the message should be printed as.
        /// </param>
        /// <param name="deleteAfter">
        /// Optional amount of time after which the debug message is being deleted.
        /// </param>
        public static void Print(string message, DebugLevel level)
        {
            Console.ForegroundColor = DebugFormat[level].FgColor;
            Console.BackgroundColor = DebugFormat[level].BgColor;
            Console.WriteLine($"[{DebugFormat[level].Prefix}] {message}");
            Console.ResetColor();
        }

    }
}
