Console.OutputEncoding = System.Text.Encoding.UTF8;
Console.Write("Veuillez saisir la hauteur du triangle : ");
int hauteur = Convert.ToInt32(Console.ReadLine());

//for (int ligne = 1; ligne <= hauteur; ligne++)
//{
//    for (int espace = 1; espace <= hauteur - ligne; espace++)
//    {
//        Console.Write(" ");
//    }
//    for(int etoile = 1; etoile <= 2 * ligne -1; etoile++)
//    {
//        Console.Write("*");
//    }
//    Console.WriteLine();
//}

// SAPIN :

List<ConsoleColor> ballColors = new List<ConsoleColor>()
{
    ConsoleColor.Red,
    ConsoleColor.Magenta,
    ConsoleColor.Blue,
    ConsoleColor.Yellow
};

Random random = new Random();

//for (int ligne = 1; ligne <= hauteur; ligne++)
//{
//    for (int espace = 1; espace <= hauteur - ligne; espace++)
//    {
//        Console.Write(" ");
//    }
//    if (ligne == 1)
//    {
//        Console.ForegroundColor = ConsoleColor.Yellow;
//        Console.WriteLine("🌟");
//        continue;
//    }
//    for (int etoile = 1; etoile <= 2 * ligne - 1; etoile++)
//    {
//        string symb;
//        if(random.NextDouble() > 0.33)
//        {
//            Console.ForegroundColor = ConsoleColor.Green;
//            symb = "*";
//        } else
//        {
//            Console.ForegroundColor = ballColors[random.Next(ballColors.Count)];
//            symb = "o";
//        }
//        Console.Write(symb);
//    }
//    Console.WriteLine();
//}

while (true)
{
    for (int ligne = 1; ligne <= hauteur; ligne++)
    {
        for (int espace = 1; espace <= hauteur - ligne; espace++)
        {
            Console.Write(" ");
        }
        if (ligne == 1)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("🌟");
            continue;
        }
        for (int etoile = 1; etoile <= 2 * ligne - 1; etoile++)
        {
            string symb;
            if (random.NextDouble() > 0.33)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                symb = "*";
            }
            else
            {
                Console.ForegroundColor = ballColors[random.Next(ballColors.Count)];
                symb = "o";
            }
            Console.Write(symb);
        }
        Console.WriteLine();
    }
    Thread.Sleep(500);
    Console.Clear();
}