using System.Collections.Generic;
using System.Linq;
using FlowControl.Application;

namespace FlowControl.Presentation
{
    /// <summary>
    /// Handles the main program menu and user interaction flow.
    /// Displays available actions, processes user choices, and executes the corresponding option.
    /// </summary>
    public class Menu
    {
        // I/O interface for writing and reading in the console (through ConsoleIO)
        private readonly IConsoleIO _io;

        // List of available menu actions implementing IMenuAction
        private readonly List<IMenuAction> _actions;

        /// <summary>
        /// Constructor for the Menu class.
        /// </summary>
        /// <param name="io">Injected IConsoleIO instance used for input and output.</param>
        /// <param name="actions">A list of all available IMenuAction options.</param>
        public Menu(IConsoleIO io, IEnumerable<IMenuAction> actions)
        {
            _io = io;
            _actions = actions.ToList();
        }

        /// <summary>
        /// Starts and controls the menu loop until the user chooses to exit.
        /// </summary>
        public void Run()
        {
            var running = true;

            while (running)
            {
                // Clear the console for a clean view each time the menu appears
                _io.Clear();

                // --- Header and introduction text ---
                _io.WriteLine("=== HUVUDMENY ===");
                _io.WriteLine("Detta lilla program innehåller flera övningar i användarinmatning och logik.");
                _io.WriteLine("Välj ett av alternativen nedan och följ instruktionerna.\n");

                // --- Display all menu actions dynamically ---
                foreach (var a in _actions)
                    _io.WriteLine($"{a.Key}. {a.Label}");

                // Add exit option manually
                _io.WriteLine("0. Avsluta");
                _io.Write("\nVälj ett alternativ: ");

                // --- Read user choice ---
                var choice = _io.ReadLine();

                if (choice == "0")
                {
                    // End program
                    _io.WriteLine("Avslutar programmet...");
                    running = false;
                }
                else
                {
                    // Try to find the selected action
                    var action = _actions.FirstOrDefault(a => a.Key == choice);

                    if (action is null)
                    {
                        // If invalid option, inform user and continue loop
                        _io.WriteLine("Ogiltigt val, försök igen!");
                    }
                    else
                    {
                        // Execute the chosen action
                        _io.Clear();
                        _io.WriteLine($"Du valde: {action.Label}\n");
                        action.Execute();
                    }

                    // Pause so the user can read output before returning to menu
                    if (running)
                    {
                        _io.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                        _io.ReadKey();
                    }
                }
            }
        }
    }
}
