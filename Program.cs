using System;
using System.Collections.Generic;

class Program
{
    static List<TodoItem> darāmoLietuSaraksts = new List<TodoItem>();

    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Izvēlieties darbību:");
            Console.WriteLine("1. Pievienot uzdevumu");
            Console.WriteLine("2. Parādīt uzdevumu sarakstu");
            Console.WriteLine("3. Atzīmēt uzdevumu kā izpildītu");
            Console.WriteLine("4. Dzēst uzdevumu");
            Console.WriteLine("5. Iziet");

            int izvēle;
            if (!int.TryParse(Console.ReadLine(), out izvēle))
            {
                Console.WriteLine("Nepareiza izvēle. Lūdzu, mēģiniet vēlreiz.");
                continue;
            }

            switch (izvēle)
            {
                case 1:
                    PievienotUzdevumu();
                    break;
                case 2:
                    ParādītUzdevumuSarakstu();
                    break;
                case 3:
                    AtzīmētKāIzpildītu();
                    break;
                case 4:
                    DzēstUzdevumu();
                    break;
                case 5:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Nepareiza izvēle. Lūdzu, mēģiniet vēlreiz.");
                    break;
            }
        }
    }

    static void PievienotUzdevumu()
    {
        Console.WriteLine("Ievadiet uzdevuma aprakstu:");
        string apraksts = Console.ReadLine();

        Console.WriteLine("Ievadiet izpildes termiņu (gggg-mm-dd):");
        if (!DateTime.TryParse(Console.ReadLine(), out DateTime termiņš))
        {
            Console.WriteLine("Nekorekta datuma formāts. Lūdzu, mēģiniet vēlreiz.");
            return;
        }

        TodoItem jaunsUzdevums = new TodoItem
        {
            Apraksts = apraksts,
            Termiņš = termiņš,
            Izpildīts = false
        };

        darāmoLietuSaraksts.Add(jaunsUzdevums);
        Console.WriteLine("Uzdevums veiksmīgi pievienots!");
    }

    static void ParādītUzdevumuSarakstu()
    {
        Console.WriteLine("Uzdevumu saraksts:");

        foreach (var uzdevums in darāmoLietuSaraksts)
        {
            Console.WriteLine($"Apraksts: {uzdevums.Apraksts}, Termiņš: {uzdevums.Termiņš}, Izpildīts: {uzdevums.Izpildīts}");
        }
    }

    static void AtzīmētKāIzpildītu()
    {
        Console.WriteLine("Ievadiet uzdevuma numuru, lai atzīmētu kā izpildītu:");
        if (!int.TryParse(Console.ReadLine(), out int numurs))
        {
            Console.WriteLine("Nekorekts uzdevuma numurs. Lūdzu, mēģiniet vēlreiz.");
            return;
        }

        if (numurs >= 0 && numurs < darāmoLietuSaraksts.Count)
        {
            darāmoLietuSaraksts[numurs].Izpildīts = true;
            Console.WriteLine("Uzdevums atzīmēts kā izpildīts!");
        }
        else
        {
            Console.WriteLine("Nekorekts uzdevuma numurs.");
        }
    }

    static void DzēstUzdevumu()
    {
        Console.WriteLine("Ievadiet uzdevuma numuru, lai to dzēstu:");
        if (!int.TryParse(Console.ReadLine(), out int numurs))
        {
            Console.WriteLine("Nekorekts uzdevuma numurs. Lūdzu, mēģiniet vēlreiz.");
            return;
        }

        if (numurs >= 0 && numurs < darāmoLietuSaraksts.Count)
        {
            darāmoLietuSaraksts.RemoveAt(numurs);
            Console.WriteLine("Uzdevums dzēsts!");
        }
        else
        {
            Console.WriteLine("Nekorekts uzdevuma numurs.");
        }
    }
}

class TodoItem
{
    public string Apraksts { get; set; }
    public DateTime Termiņš { get; set; }
    public bool Izpildīts { get; set; }
}

\\ My repository 