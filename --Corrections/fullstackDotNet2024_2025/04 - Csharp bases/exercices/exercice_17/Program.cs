Console.Write("Veuillez saisir l'age de votre enfant :  ");
int age = Convert.ToInt32(Console.ReadLine());

switch (age)
{
    case < 3:
        Console.WriteLine("Votre enfant est trop jeune");
        break;
    case <= 6:
        Console.WriteLine("Baby");
        break;
    case <= 8:
        Console.WriteLine("Poussin");
        break;
    case <= 10:
        Console.WriteLine("Pupille");
        break;
    case <= 12:
        Console.WriteLine("Minime");
        break;
    case <= 17:
        Console.WriteLine("Cadet");
        break;
    default:
        Console.WriteLine("Votre enfant est trop vieux !");
        break;
}