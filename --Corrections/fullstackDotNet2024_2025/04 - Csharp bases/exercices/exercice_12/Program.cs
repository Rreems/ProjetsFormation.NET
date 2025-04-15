Console.Write("Veuillez saisir l'age de votre enfant :  ");
int age = Convert.ToInt32(Console.ReadLine());

if (age < 3)
{
    Console.WriteLine("Votre enfant est trop jeune");
} else if (age <= 6)
{
    Console.WriteLine("Baby");
} else if (age <= 8)
{
    Console.WriteLine("Poussin");
} else if (age <= 10)
{
    Console.WriteLine("Pupille");
} else if (age <= 12)
{
    Console.WriteLine("Minime");
} else if (age <= 17)
{
    Console.WriteLine("Cadet");
} else
{
    Console.WriteLine("Votre enfant est trop vieux !");
}