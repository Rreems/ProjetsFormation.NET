Console.Write("Veuillez saisir la longueur du segment AB :  ");
double ab = Convert.ToDouble(Console.ReadLine());

Console.Write("Veuillez saisir la longueur du segment BC :  ");
double bc = Convert.ToDouble(Console.ReadLine());

Console.Write("Veuillez saisir la longueur du segment CA :  ");
double ca = Convert.ToDouble(Console.ReadLine());

if (ab == bc && ab == ca)
{
    Console.WriteLine("Le triangle ABC est équilatéral");
} else if (ab == bc)
{
    Console.WriteLine("Le triangle ABC est isocèle en B");
} else if (ab == ca)
{
    Console.WriteLine("Le triangle ABC est isocèle en A");
}
else if (ca == bc)
{
    Console.WriteLine("Le triangle ABC est isocèle en C");
} else
{
    Console.WriteLine("Le triangle ABC est quelconque");
}