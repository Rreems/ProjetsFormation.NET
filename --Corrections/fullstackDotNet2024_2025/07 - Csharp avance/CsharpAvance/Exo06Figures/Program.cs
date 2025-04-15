using Exo06Figures.Classes;
using Exo06Figures.Classes.Figures;

Carre carre = new Carre(2, 4, 2);
Console.WriteLine(carre);
Console.WriteLine("-------------------");

Rectangle rectangle = new Rectangle(2, 4, 3, 5);
Console.WriteLine(rectangle);

//Point monPoint = new Point(2, 4);
//Rectangle rectangle2 = new Rectangle(monPoint, 3, 5);
//Console.WriteLine(rectangle2);

//Rectangle rectangle3 = new Rectangle(new Point(2, 4), 3, 5);
//Console.WriteLine(rectangle3);

Console.WriteLine("-------------------");

Triangle triangle = new Triangle(2, 4, 4, 5);
Console.WriteLine(triangle.ToString());

Console.WriteLine("-------------------");

Console.WriteLine("Deplacement du carré par (1,3) :\n");
carre.Deplacement(1, 3);
Console.WriteLine(carre);