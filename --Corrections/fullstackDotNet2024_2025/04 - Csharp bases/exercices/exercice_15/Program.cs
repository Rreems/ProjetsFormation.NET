decimal indemnite = 0;

Console.Write("Veuillez saisir votre dernier salaire :  ");
decimal salaire = Convert.ToDecimal(Console.ReadLine());

Console.Write("Veuillez saisir votre age :  ");
int age = Convert.ToInt32(Console.ReadLine());

Console.Write("Veuillez saisir l'ancienneté :  ");
int anciennete = Convert.ToInt32(Console.ReadLine());

if (anciennete >= 1 && anciennete <= 10)
{
    indemnite += anciennete * salaire / 2;
} else
{
    indemnite += 10 * salaire / 2 + (anciennete - 10) * salaire;
}

if (anciennete >= 1 && age > 45)
{
    indemnite += (age < 50) ? 2 * salaire : 5 * salaire;
}

Console.WriteLine($"Votre indemnité est de de {indemnite} euros");