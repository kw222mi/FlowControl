using FlowControl.Application;
using FlowControl.Domain;
using FlowControl.Presentation;

namespace FlowControl.Application
{
    /// <summary>
    /// Represents the menu action for calculating the ticket price
    /// based on a single person's age.
    /// </summary>
    public class AgePricingAction : IMenuAction
    {
        // I/O handler for reading and writing to the console
        private readonly IConsoleIO _io;

        /// <summary>
        /// Constructor for AgePricingAction.
        /// </summary>
        /// <param name="io">Injected IConsoleIO instance used for console interaction.</param>
        public AgePricingAction(IConsoleIO io) => _io = io;

        // Unique key for selecting this action in the menu
        public string Key => "1";

        // Label displayed in the main menu
        public string Label => "Ungdom eller pensionär";

        /// <summary>
        /// Executes the logic for determining the ticket price based on age.
        /// </summary>
        public void Execute()
        {
            // --- Header and introduction ---
            _io.WriteLine("=== Ungdom eller pensionär ===");
            _io.WriteLine("Här får du fram biljettpriset baserat på ålder.\n");

            // Ask for the user's age (validated integer input)
            var age = InputReader.ReadInt(_io, "Ange din ålder: ", min: 0);

            // Get the ticket price using the domain logic
            var price = TicketPriceCalculator.GetTicketPrice(age);

            // --- Display result ---
            if (price == 0)
                _io.WriteLine("Gratis!");
            else if (age < 20)
                _io.WriteLine($"Ungdomspris: {price} kr");
            else if (age >= 65)
                _io.WriteLine($"Pensionärspris: {price} kr");
            else
                _io.WriteLine($"Standardpris: {price} kr");
        }
    }
}
