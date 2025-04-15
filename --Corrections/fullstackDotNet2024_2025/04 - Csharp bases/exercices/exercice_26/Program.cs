Random aleatoire = new Random();
int nbMystere = aleatoire.Next(1, 51);
int choix = 0, nbCoups = 0;

while (choix != nbMystere)
{
    Console.Write("Veuillez saisir un nombre entre 1 et 50 : ");
    while (!int.TryParse(Console.ReadLine(), out choix) || choix < 1 || choix > 50)
    {
        Console.WriteLine("Saisie invalide ! ");
    }
    nbCoups++;

    if (choix > nbMystere)
    {
        Console.WriteLine("Le nombre mystère est plus petit !");
    } else if (choix < nbMystere)
    {
        Console.WriteLine("Le nombre mystère est plus grand !");
    }
}

Console.WriteLine("Bravo !! vous avez trouvé le nombre mystère !");
Console.WriteLine($"Vous avez trouvé en {nbCoups} coups");