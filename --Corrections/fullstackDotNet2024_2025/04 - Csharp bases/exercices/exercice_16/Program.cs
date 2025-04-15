Console.WriteLine(@"Listedes boissons disponibles :
        1) Eau plate
        2) Eau gazeuse
        3) Coca-Cola
        4) Fanta
        5) Sprite
        6) Orangina
        7) 7up");

Console.Write("Faites votre choix (1 à 7) : ");
string choix = Console.ReadLine();
string boisson = "";

switch (choix)
{
    case "1":
        boisson = "Eau plate";
        break;
    case "2":
        boisson = "Eau gazeuse";
        break;
    case "3":
        boisson = "Coca-Cola";
        break;
    case "4":
        boisson = "Fanta";
        break;
    case "5":
        boisson = "Sprite";
        break;
    case "6":
        boisson = "Orangina";
        break;
    case "7":
        boisson = "7Up";
        break;
    default:
        Console.WriteLine("Mauvaix choix !");
        break;
}

if (boisson != "")
{
    Console.WriteLine($"Votre {boisson} est servi !");
}