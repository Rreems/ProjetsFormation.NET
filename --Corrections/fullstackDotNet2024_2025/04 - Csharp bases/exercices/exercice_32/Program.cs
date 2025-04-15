// Avec tableaux 

string[] players = new string[17]
{

        "Mamadou",
        "Mattéo",
        "Leslie",
        "Melvin",
        "Jamel",
        "Léandre",
        "Medhi",
        "Théo H",
        "Alexandre",
        "Rémi",
        "Lucas",
        "Théo W",
        "Ronan",
        "Guillaume",
        "Mathieu",
        "Gaëlle",
        "Valentin"
};

string[] winners = new string[17];
int i = 0;
string espace = "";

while (true)
{
    Console.ResetColor();
    Console.WriteLine("=== Tirage au sort ===");
    Console.WriteLine(@"
1. Effectuer le tirage
2. Afficher la liste des participants
3. Afficher la liste des gagnants
0. Quitter l'application");

    Console.Write("Faites votre choix : ");
    string choice = Console.ReadLine();

    switch (choice)
    {
        case "0":
            Environment.Exit(0);
            break;
        case "1":
            Random random = new Random();
            int index = random.Next(0, players.Length);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"*** L'heureux.se gagnant.e est : {players[index]} !! ***");
            Console.ResetColor();

            winners[i] = players[index];
            i++;

            players[index] = players[players.Length - 1];

            Array.Resize(ref players, players.Length - 1);

            if (players.Length == 0)
            {
                players = (string[])winners.Clone();
                Array.Clear(winners, 0, 17);
                i = 0;
                Console.WriteLine("Il n'y a plus de candidats, on réinitialise nos tableaux");
            }
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("---- Liste des personnes tirées au sort ----");
            Console.ResetColor();
            espace = "";
            foreach (string winner in winners)
            {
                Console.WriteLine($"{espace}{winner}");
                espace += " ";
            }
            break;
        case "2":
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("---- Liste des personnes en attente ----");
            Console.ResetColor();
            espace = "";
            foreach (string player in players)
            {
                Console.WriteLine($"{espace}{player}");
                espace += " ";
            }
            break;
        default:
            Console.Clear();
            break;
    }
}

// avec liste :

//List<string> players = new List<string>
//{

//        "Mamadou",
//        "Mattéo",
//        "Leslie",
//        "Melvin",
//        "Jamel",
//        "Léandre",
//        "Medhi",
//        "Théo H",
//        "Alexandre",
//        "Rémi",
//        "Lucas",
//        "Théo W",
//        "Ronan",
//        "Guillaume",
//        "Mathieu",
//        "Gaëlle",
//        "Valentin"
//};

//List<string> winners = new List<string>();
//string espace = "";

//while (true)
//{
//    Console.WriteLine("=== Tirage au sort ===");
//    Console.WriteLine(@"
//1. Effectuer le tirage
//2. Afficher la liste des participants
//3. Afficher la liste des gagnants
//0. Quitter l'application");

//    Console.Write("Faites votre choix : ");
//    string choice = Console.ReadLine();

//    switch (choice)
//    {
//        case "0":
//            Environment.Exit(0);
//            break;
//        case "1":
//            Random random = new Random();
//            int index = random.Next(0, players.Count);
//            Console.ForegroundColor = ConsoleColor.Green;
//            Console.WriteLine($"*** L'heureux.se gagnant.e est : {players[index]} !! ***");
//            Console.ResetColor();
//            winners.Add(players[index]);
//            players.Remove(players[index]);


//            if (players.Count == 0)
//            {
//                players = winners;
//                winners.Clear();
//                Console.WriteLine("Il n'y a plus de candidats, on réinitialise nos tableaux");
//            }
//            break;
//        case "3":
//            Console.ForegroundColor = ConsoleColor.Cyan;
//            Console.WriteLine("---- Liste des personnes tirées au sort ----");
//            Console.ResetColor();
//            espace = "";
//            foreach (string winner in winners)
//            {
//                Console.WriteLine($"{espace}{winner}");
//                espace += " ";
//            }
//            break;
//        case "2":
//            Console.ForegroundColor = ConsoleColor.Red;
//            Console.WriteLine("---- Liste des personnes en attente ----");
//            Console.ResetColor();
//            espace = "";
//            foreach (string player in players)
//            {
//                Console.WriteLine($"{espace}{player}");
//                espace += " ";
//            }
//            break;
//        default:
//            Console.Clear();
//            break;
//    }
//}