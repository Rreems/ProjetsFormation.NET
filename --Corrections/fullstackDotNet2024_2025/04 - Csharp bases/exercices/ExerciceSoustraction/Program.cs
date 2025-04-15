long Soustraire(long a, long b)
{
    Console.WriteLine($"Je soustrais {a} et {b}");
    return a - b;
}

long sub = Soustraire(2, 1);
Console.WriteLine("Résultat : " + sub);

sub = Soustraire(150, 50);
Console.WriteLine("Résultat : " + sub);
