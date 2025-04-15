Console.Write("Veuillez saisir la longueur d'un côté du carré (en cm) : ");
double cote = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Périmètre : " + cote * 4);
Console.WriteLine("Aire : " + cote * cote);

Console.Write("Veuillez saisir la longueur  du rectangle (en cm) : ");
double longueur = Convert.ToDouble(Console.ReadLine());
Console.Write("\nVeuillez saisir la largeur du rectangle (en cm) : ");
double largeur = Convert.ToDouble(Console.ReadLine());

Console.WriteLine("Périmètre : " + (longueur + largeur) * 2);
Console.WriteLine("Aire : " + longueur * largeur);