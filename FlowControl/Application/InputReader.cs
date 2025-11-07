using FlowControl.Presentation;

namespace FlowControl.Application
{
    /// <summary>
    /// Provides helper methods for reading and validating numeric input from the user.
    /// </summary>
    public static class InputReader
    {
        /// <summary>
        /// Reads an integer value from the user, with optional minimum and maximum validation.
        /// Keeps prompting until a valid number is entered.
        /// </summary>
        /// <param name="io">Console I/O interface used for reading and writing.</param>
        /// <param name="prompt">Message shown to the user before reading input.</param>
        /// <param name="min">Optional minimum allowed value.</param>
        /// <param name="max">Optional maximum allowed value.</param>
        /// <returns>A valid integer entered by the user within the given range.</returns>
        public static int ReadInt(IConsoleIO io, string prompt, int? min = null, int? max = null)
        {
            while (true)
            {
                // Prompt user for input
                io.Write(prompt);
                var input = io.ReadLine();

                // Try to convert input to integer
                if (!int.TryParse(input, out var value))
                {
                    io.WriteLine("Ogiltig inmatning. Skriv ett heltal.");
                    continue; // Ask again
                }

                // Check minimum constraint
                if (min.HasValue && value < min.Value)
                {
                    io.WriteLine($"Talet måste vara minst {min.Value}.");
                    continue;
                }

                // Check maximum constraint
                if (max.HasValue && value > max.Value)
                {
                    io.WriteLine($"Talet får vara högst {max.Value}.");
                    continue;
                }

                // Valid input → return the number
                return value;
            }
        }
    }
}
