using FlowControl.Presentation;
using FlowControl.Application;

namespace FlowControl
{
    /// <summary>
    /// Entry point for the FlowControl application.
    /// Initializes dependencies and starts the interactive console menu.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Main startup method of the application.
        /// Responsible for wiring together the presentation and application layers.
        /// </summary>
        static void Main()
        {
            // --- Initialize the I/O handler ---
            // Handles all user interaction (input/output) via the console.
            var io = new ConsoleIO();

            // --- Define available menu actions ---
            // Each action implements IMenuAction and represents one menu option.
            var actions = new IMenuAction[]
            {
                new AgePricingAction(io),
                new GroupPricingAction(io),
                new RepeatTextAction(io),
                new ThirdWordAction(io),
            };

            // --- Create and run the main menu ---
            // The Menu class controls the user flow and executes the selected action.
            var menu = new Menu(io, actions);
            menu.Run();
        }
    }
}
