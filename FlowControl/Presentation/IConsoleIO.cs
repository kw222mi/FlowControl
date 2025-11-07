using System;

namespace FlowControl.Presentation
{
    /// <summary>
    /// Defines an abstraction layer for all console input and output operations.
    /// 
    /// By using this interface, the application logic can remain independent
    /// of direct console access, which improves testability and separation of concerns.
    /// </summary>
    public interface IConsoleIO
    {
        /// <summary>
        /// Writes text to the console without appending a newline.
        /// </summary>
        /// <param name="text">The text to display.</param>
        void Write(string text);

        /// <summary>
        /// Writes text to the console followed by a newline.
        /// If no text is provided, it simply writes an empty line.
        /// </summary>
        /// <param name="text">The text to display (optional).</param>
        void WriteLine(string text = "");

        /// <summary>
        /// Reads a full line of text from the console.
        /// The return value is never null; an empty string is returned instead.
        /// </summary>
        /// <returns>User-entered text as a string.</returns>
        string ReadLine();

        /// <summary>
        /// Waits for a single key press from the user without echoing it to the console.
        /// Commonly used to pause execution between menu screens.
        /// </summary>
        void ReadKey();

        /// <summary>
        /// Clears all text from the console window.
        /// </summary>
        void Clear();
    }
}
