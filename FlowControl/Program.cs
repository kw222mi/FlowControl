
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
            // TODO: anropa metoden för menyval 1
            break;

        case "2":
            Console.WriteLine("Du valde: Grupppris");
            // TODO: anropa metoden för menyval 2
            break;

        case "3":
            Console.WriteLine("Du valde: Upprepa tio gånger");
            // TODO: anropa metoden för menyval 3
            break;

        case "4":
            Console.WriteLine("Du valde: Det tredje ordet");
            // TODO: anropa metoden för menyval 4
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