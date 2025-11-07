using FlowControl.Domain;
using FlowControl.Presentation;

namespace FlowControl.Application
{
    /// <summary>
    /// Represents the menu action for calculating total group price
    /// based on the ages of multiple people.
    /// </summary>
    public class GroupPricingAction : IMenuAction
    {
        // Handles all input/output operations through the console interface
        private readonly IConsoleIO _io;

        // Unique key for selecting this action in the menu
        public string Key => "2";

        // Label displayed in the main menu
        public string Label => "Grupppris";

        /// <summary>
        /// Constructor for GroupPricingAction.
        /// </summary>
        /// <param name="io">Injected IConsoleIO instance used for console interaction.</param>
        public GroupPricingAction(IConsoleIO io) => _io = io;

        /// <summary>
        /// Executes the group price calculation logic.
        /// </summary>
        public void Execute()
        {
            // --- Header and introduction ---
            _io.WriteLine("=== Grupppris ===");
            _io.WriteLine("Beräkna totalpriset för en grupp baserat på varje persons ålder.\n");

            // Ask how many people are in the group (must be at least 1)
            int count = InputReader.ReadInt(_io, "Hur många personer? ", min: 1);

            // Accumulator for total price
            int total = 0;

            // --- Loop over each person in the group ---
            for (int i = 1; i <= count; i++)
            {
                // Ask for the person's age
                int age = InputReader.ReadInt(_io, $"Ange ålder för person {i}: ", min: 0);

                // Get individual price from domain logic
                int price = TicketPriceCalculator.GetTicketPrice(age);

                // Add to the total
                total += price;

                // Show price for each person
                _io.WriteLine($"Person {i}: {price} kr");
            }

            // --- Summary output ---
            _io.WriteLine($"\nAntal personer: {count}");
            _io.WriteLine($"Totalt pris: {total} kr\n");
        }
    }
}
