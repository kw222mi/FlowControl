

using FlowControl.Presentation;
using FlowControl.Application;
using FlowControl.Domain;

namespace FlowControl;
class Program
{
    static void Main()
    {
        var io = new ConsoleIO();

        var actions = new IMenuAction[]
        {
            new AgePricingAction(io),
            new GroupPricingAction(io),
            new RepeatTextAction(io),
            new ThirdWordAction(io),
        };

        var menu = new Menu(io, actions);
        menu.Run();
    }
}

/*


// Main program loop flag
bool running = true;

while (running)
{
    // Clear the console for a fresh menu display each iteration
    Console.Clear();

    // --- Main menu UI ---
    Console.WriteLine("=== HUVUDMENY ===");
    Console.WriteLine("1. Ungdom eller pensionär");
    Console.WriteLine("2. Grupppris");
    Console.WriteLine("3. Upprepa tio gånger");
    Console.WriteLine("4. Det tredje ordet");
    Console.WriteLine("0. Avsluta");
    Console.Write("\nVälj ett alternativ: ");

    // Read user menu choice as a raw string (we compare as text below)
    string choice = Console.ReadLine();

    // Route to the selected feature
    switch (choice)
    {
        case "1":
            Console.WriteLine("Du valde: Ungdom eller pensionär");
            GetAgeGroup();         // Menu option 1
            break;

        case "2":
            Console.WriteLine("Du valde: Grupppris");
            GroupPrice();          // Menu option 2
            break;

        case "3":
            Console.WriteLine("Du valde: Upprepa tio gånger");
            RepeatText();          // Menu option 3
            break;

        case "4":
            Console.WriteLine("Du valde: Det tredje ordet");
            TheThirdWord();        // Menu option 4
            break;

        case "0":
            Console.WriteLine("Avslutar programmet...");
            running = false;       // Exit the main loop
            break;

        default:
            // Any non-recognized input ends up here
            Console.WriteLine("Ogiltigt val, försök igen!");
            break;
    }

    // Pause so the user can read the output before showing the menu again
    if (running)
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}

// --- Menu option 1: Single age -> ticket price ---
static void GetAgeGroup()
{
    Console.WriteLine("=== Ungdom eller pensionär ===");

    // Read a non-negative integer; ReadInt handles validation/retries
    int age = ReadInt("Ange din ålder: ", min: 0);

    // Centralized pricing logic (shared with group pricing)
    int price = GetTicketPrice(age);

    // Present result based on computed price and age category
    if (price == 0)
    {
        Console.WriteLine("Gratis!");
    }
    else if (age < 20)
    {
        Console.WriteLine($"Ungdomspris: {price} kr");
    }
    else if (age >= 65)
    {
        Console.WriteLine($"Pensionärspris: {price} kr");
    }
    else
    {
        Console.WriteLine($"Standardpris: {price} kr");
    }
}






// --- Helper: Robust integer input reader with optional bounds ---
static int ReadInt(string prompt, int? min = null, int? max = null)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        // Try to parse; if it fails, inform and retry
        if (!int.TryParse(input, out int value))
        {
            Console.WriteLine("Ogiltig inmatning. Skriv ett heltal.");
            continue;
        }

        // Check lower bound if provided
        if (min.HasValue && value < min.Value)
        {
            Console.WriteLine($"Talet måste vara minst {min.Value}.");
            continue;
        }

        // Check upper bound if provided
        if (max.HasValue && value > max.Value)
        {
            Console.WriteLine($"Talet får vara högst {max.Value}.");
            continue;
        }

        // Valid value
        return value;
    }
}*/


