Console.Write("Veuillez saisir un chiffre/nombre entier :  ");
int nb1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Veuillez saisir un chiffre/nombre diviseur :  ");
int nb2 = Convert.ToInt32(Console.ReadLine());

if (nb1 % nb2 == 0)
{
    Console.WriteLine($"le nombre {nb1} est divisible par {nb2}");
} else
{
    Console.WriteLine($"le nombre {nb1} n'est pas divisible par {nb2}");
}
