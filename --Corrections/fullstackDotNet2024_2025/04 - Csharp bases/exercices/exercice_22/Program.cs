double max = 0, min = 20, somme = 0, moyenne, note;

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

moyenne = somme / 5;
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"La meilleure note est {max}/20");
Console.ForegroundColor = ConsoleColor.Red;
Console.WriteLine($"La moins bonne note est {min}/20");
//Console.ForegroundColor = ConsoleColor.Gray;
Console.ResetColor();
Console.WriteLine($"La moyenne des notes est {moyenne}/20");