
bool running = true;

while (running)
{
    Console.Clear();
    Console.WriteLine("=== HUVUDMENY ===");
    Console.WriteLine("1. Ungdom eller pensionär");
    Console.WriteLine("2. Grupppris");
    Console.WriteLine("3. Upprepa tio gånger");
    Console.WriteLine("4. Det tredje ordet");
    Console.WriteLine("0. Avsluta");
    Console.Write("\nVälj ett alternativ: ");

    string choice = Console.ReadLine();

    switch (choice)
    {
        case "1":
            Console.WriteLine("Du valde: Ungdom eller pensionär");
            GetAgeGroup();
            break;

        case "2":
            Console.WriteLine("Du valde: Grupppris");
            GroupPrice();
            break;

        case "3":
            Console.WriteLine("Du valde: Upprepa tio gånger");
            RepeatText();
            break;

        case "4":
            Console.WriteLine("Du valde: Det tredje ordet");
            TheThirdWord();
            break;

        case "0":
            Console.WriteLine("Avslutar programmet...");
            running = false;
            break;

        default:
            Console.WriteLine("Ogiltigt val, försök igen!");
            break;
    }

    if (running)
    {
        Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
        Console.ReadKey();
    }
}

static void GetAgeGroup()
{
    Console.WriteLine("=== Ungdom eller pensionär ===");

    int age = ReadInt("Ange din ålder: ", min: 0);
    int price = GetTicketPrice(age);

    // View the result based on age and price 
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


static void GroupPrice()
{
    Console.WriteLine("=== Grupppris ===");

    int count = ReadInt("Hur många personer? ", min: 1);

    int total = 0;

    for (int i = 1; i <= count; i++)
    {
        int age = ReadInt($"Ange ålder för person {i}: ", min: 0);
        int price = GetTicketPrice(age);
        total += price;

        Console.WriteLine($"Person {i}: {price} kr");
    }

    Console.WriteLine($"\nAntal personer: {count}");
    Console.WriteLine($"Totalt: {total} kr");
}

static void RepeatText()
{
    Console.WriteLine("Ange ett ord/text som du vill upprepa: ");
    string repetText = Console.ReadLine();
    Console.WriteLine("\nResultat:");
    int numberOfTimes = 10;

    for (int i = 0; i < numberOfTimes; i++)
    {
        // write the text
        Console.Write($"{i + 1}. {repetText}");

        // add comma if it is not the last word
        if (i < numberOfTimes-1)
        {
            Console.Write(", ");
        }
    
    }
    Console.WriteLine();

}

static void TheThirdWord() {
    Console.WriteLine("Skriv en mening (minst tre ord): ");
    string input = (Console.ReadLine() ?? string.Empty).Trim();
    var words = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
    if (words.Length < 3)
    {
        Console.WriteLine("Meningen var för kort, prova igen: ");
    }

    else { Console.WriteLine(words[2]); }


}
static int ReadInt(string prompt, int? min = null, int? max = null)
{
    while (true)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();

        if (!int.TryParse(input, out int value))
        {
            Console.WriteLine("Ogiltig inmatning. Skriv ett heltal.");
            continue;
        }

        if (min.HasValue && value < min.Value)
        {
            Console.WriteLine($"Talet måste vara minst {min.Value}.");
            continue;
        }
        if (max.HasValue && value > max.Value)
        {
            Console.WriteLine($"Talet får vara högst {max.Value}.");
            continue;
        }

        return value;
    }
}

static int GetTicketPrice(int age)
{
    if (age < 5 || age > 100) return 0;  
    if (age < 20) return 80;
    if (age >= 65) return 90;
    return 120;
}