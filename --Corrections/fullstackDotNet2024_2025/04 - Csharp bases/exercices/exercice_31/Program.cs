Console.WriteLine("Veuillez saisir le nombre de contact : ");
int nb = Convert.ToInt32(Console.ReadLine());
string[] tab = new string[nb];
string choix;
Console.Clear();

do
{
    Console.WriteLine(@"==== GESTION DES CONTACTS ====
    1---Saisir les contacts
    2---Afficher les contacts
    0---Quitter");

    Console.Write("Faites votre choix : ");
    choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==== Saisir les contacts ====");
            Console.ResetColor();
            for (int i = 0; i < tab.Length; i++){
                Console.Write($"Nom et prénom du contact n°{i + 1} : ");
                tab[i] = Console.ReadLine();
            }
            Console.Clear();
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==== Afficher les contacts ====");
            Console.ResetColor();
            for (int i = 0; i < tab.Length; i++)
            {
                Console.Write($"contact n°{i + 1} : {tab[i]}");
            }
            Console.WriteLine("Appuyez sur une touche pour retourner au menu.");
            Console.ReadKey();
            Console.Clear();
            break;
        case "0":
            Environment.Exit(0);
            break;
    }
} while (true);