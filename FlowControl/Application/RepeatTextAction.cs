using FlowControl.Domain;
using FlowControl.Presentation;

namespace FlowControl.Application
{
    /// <summary>
    /// Represents the menu action that repeats a given text a fixed number of times.
    /// Uses domain logic to build the repeated string and then displays it to the user.
    /// </summary>
    public class RepeatTextAction : IMenuAction
    {
        // I/O handler used for reading input and writing output
        private readonly IConsoleIO _io;

        // Unique key for selecting this action in the menu
        public string Key => "3";

        // Label displayed in the main menu
        public string Label => "Upprepa tio gånger";

        /// <summary>
        /// Constructor for RepeatTextAction.
        /// </summary>
        /// <param name="io">Injected IConsoleIO instance used for console interaction.</param>
        public RepeatTextAction(IConsoleIO io) => _io = io;

        /// <summary>
        /// Executes the logic for repeating a text a number of times.
        /// </summary>
        public void Execute()
        {
            // --- Header and setup ---
            _io.WriteLine("=== Upprepa text ===");
            _io.WriteLine("Denna funktion upprepar den text du anger tio gånger.\n");

            int numberOfTimes = 10;

            // Ask user for the text to repeat
            _io.Write("Ange ett ord eller en text att upprepa: ");
            string input = _io.ReadLine();

            // --- Domain layer: build the repeated string ---
            string result = TextUtilities.BuildRepetitions(input, numberOfTimes);

            // --- Application layer: display the result ---
            _io.WriteLine("\n=== Resultat ===");
            _io.WriteLine(result + "\n");
        }
    }
}
