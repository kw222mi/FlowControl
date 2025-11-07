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

// --- Menu option 2: Group pricing (sum across several ages) ---
static void GroupPrice()
{
    Console.WriteLine("=== Grupppris ===");

    // Ask how many people; must be at least 1
    int count = ReadInt("Hur många personer? ", min: 1);

    int total = 0; // accumulator for total price

    // Loop over each person and collect their age
    for (int i = 1; i <= count; i++)
    {
        int age = ReadInt($"Ange ålder för person {i}: ", min: 0);
        int price = GetTicketPrice(age);
        total += price;

        Console.WriteLine($"Person {i}: {price} kr");
    }

    // Summary output
    Console.WriteLine($"\nAntal personer: {count}");
    Console.WriteLine($"Totalt: {total} kr");
}

// --- Menu option 3: Repeat an input string 10 times on the same line ---
static void RepeatText()
{
    Console.WriteLine("Ange ett ord/text som du vill upprepa: ");
    string repetText = Console.ReadLine();

    Console.WriteLine("\nResultat:");
    int numberOfTimes = 10;

    for (int i = 0; i < numberOfTimes; i++)
    {
        // Write the numbered repetition without line break
        Console.Write($"{i + 1}. {repetText}");

        // Add a comma and space between items, but not after the last one
        if (i < numberOfTimes - 1)
        {
            Console.Write(", ");
        }
    }

    // Final line break so subsequent output starts on a new line
    Console.WriteLine();
}

// --- Menu option 4: Read a sentence and print the third word ---
// Re-prompts until the user provides at least three words.
static void TheThirdWord()
{
    while (true)
    {
        Console.WriteLine("Skriv en mening (minst tre ord): ");

        // Read full line, guard against null, and trim extra spaces
        string input = (Console.ReadLine() ?? string.Empty).Trim();

        // Split on spaces and discard empty entries (handles multiple spaces)
        var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

        // Validate we have at least three words before accessing index 2
        if (words.Length < 3)
        {
            Console.WriteLine("Meningen var för kort, prova igen: ");
            continue; // ask again
        }

        // Third word is at index 2 (0-based indexing)
        Console.WriteLine(words[2]);
        break; // success -> leave the loop
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
}

// --- Helper: Central ticket price rules (single source of truth) ---
static int GetTicketPrice(int age)
{
    // Optional bonus rule: free for <5 or >100
    if (age < 5 || age > 100) return 0;

    // Base rules
    if (age < 20) return 80;
    if (age >= 65) return 90;

    // Default price
    return 120;
}
