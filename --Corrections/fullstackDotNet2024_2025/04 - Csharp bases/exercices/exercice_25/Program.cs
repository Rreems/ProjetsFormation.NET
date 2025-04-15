double max = 0, min = 20, somme = 0, moyenne, note;
bool quitter = false;

do
{
    Console.WriteLine(@"==== MENU ====
1----Saisir les notes
2----La plus grande note
3----La plus petite note
4----La moyenne des note
0----Quitter");
    string choice = Console.ReadLine();
    
    switch (choice)
    {
        case "1":
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"Veuillez saisir la note n°{i} (sur/20) : ");
                //double note = Convert.ToDouble(Console.ReadLine());
                while (!double.TryParse(Console.ReadLine(), out note) || note < 0 || note > 20)
                    Console.WriteLine("Saisie invalide, merci de saisir une note entre 0 et 20");

                if (note > max)
                {
                    max = note;
                }
                if (note < min)
                {
                    min = note;
                }
                somme += note;

            }
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"La meilleure note est {max}/20");
            Console.ResetColor();
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"La moins bonne note est {min}/20");
            Console.ResetColor();
            break;
        case "4":
            moyenne = somme / 5;
            Console.WriteLine($"La moyenne des notes est {moyenne}/20");
            break;
        case "0":
            quitter = true;
            break;
        default:
            Console.WriteLine("Erreur de saisie, recommencer !");
            break;
    }
} while (!quitter);