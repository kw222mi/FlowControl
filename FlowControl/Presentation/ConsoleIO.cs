using System;

namespace FlowControl.Presentation
{
    /// <summary>
    /// Provides a concrete implementation of <see cref="IConsoleIO"/> 
    /// that handles all input and output operations via the system console.
    /// 
    /// This abstraction makes the application easier to test and maintain,
    /// since the console interactions are isolated from the application logic.
    /// </summary>
    public class ConsoleIO : IConsoleIO
    {
        /// <summary>
        /// Writes text to the console without a line break.
        /// </summary>
        /// <param name="text">The text to display.</param>
        public void Write(string text) => Console.Write(text);

        /// <summary>
        /// Writes text to the console followed by a line break.
        /// </summary>
        /// <param name="text">The text to display (optional).</param>
        public void WriteLine(string text = "") => Console.WriteLine(text);

        /// <summary>
        /// Reads a full line of text from the console.
        /// Returns an empty string if the input is null.
        /// </summary>
        /// <returns>User-entered text as a string.</returns>
        public string ReadLine() => Console.ReadLine() ?? string.Empty;

        /// <summary>
        /// Waits for a single key press from the user without echoing it to the console.
        /// Used to pause the program between actions.
        /// </summary>
        public void ReadKey() => Console.ReadKey(intercept: true);

        /// <summary>
        /// Clears the console window.
        /// </summary>
        public void Clear() => Console.Clear();
    }
}
