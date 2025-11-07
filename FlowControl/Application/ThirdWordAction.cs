using FlowControl.Presentation;
using FlowControl.Domain;

namespace FlowControl.Application
{
    /// <summary>
    /// Represents the menu action for extracting the third word from a given sentence.
    /// Uses domain logic to validate and return the result.
    /// </summary>
    public class ThirdWordAction : IMenuAction
    {
        // I/O handler for reading and writing through the console
        private readonly IConsoleIO _io;

        // Unique key for selecting this action in the main menu
        public string Key => "4";

        // Label displayed in the main menu
        public string Label => "Det tredje ordet";

        /// <summary>
        /// Constructor for ThirdWordAction.
        /// </summary>
        /// <param name="io">Injected IConsoleIO instance used for console interaction.</param>
        public ThirdWordAction(IConsoleIO io) => _io = io;

        /// <summary>
        /// Executes the logic for reading a sentence and extracting the third word.
        /// </summary>
        public void Execute()
        {
            // --- Header ---
            _io.WriteLine("=== Det tredje ordet ===");
            _io.WriteLine("Skriv en mening med minst tre ord. Programmet visar det tredje ordet.\n");

            while (true)
            {
                // Prompt user for input
                _io.Write("Skriv en mening (minst tre ord): ");
                string input = _io.ReadLine();

                try
                {
                    // --- Domain layer: extract the third word ---
                    string thirdWord = TextUtilities.GetThirdWord(input);

                    // --- Application layer: show result ---
                    _io.WriteLine($"\nDet tredje ordet är: {thirdWord}\n");

                    // Stop loop on success
                    break;
                }
                catch (ArgumentException ex)
                {
                    // --- Handle validation errors ---
                    // _io.WriteLine(ex.Message);
                    _io.WriteLine("Meningen måste innehålla minst tre ord.");
                    _io.WriteLine("Försök igen!\n");
                }
            }
        }
    }
}
