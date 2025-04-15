Console.WriteLine(@"Quelle est l'instruction qui permet de sortir d'une boucle en C# ?
    a) quit
    b) continue
    c) break
    d) exit");

string reponse, nouvelEssai;

do
{
    Console.Write("Veuillez entrer votre réponse : ");
    reponse = Console.ReadLine();

    if (reponse == "c")
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Bonne réponse !!!");
        Console.ResetColor();
        break;
        // Environment.Exit(0);
    } else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("mauvaise réponse !!!");
        Console.ResetColor();
        Console.Write("Nouvel essai ? oui / non : ");
        nouvelEssai = Console.ReadLine().ToUpper();
    }

} while (nouvelEssai == "OUI");