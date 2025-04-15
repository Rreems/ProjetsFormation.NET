Console.Write("Veuillez saisir votre taille (en cm) :  ");
int taille = Convert.ToInt32(Console.ReadLine());

Console.Write("Veuillez saisir votre poids (en kg) :  ");
int poids = Convert.ToInt32(Console.ReadLine());

if (taille >= 145 && taille < 172 && poids >= 43 && poids <= 47
   || taille >= 145 && taille < 169 && poids >= 48 && poids <= 53
   || taille >= 145 && taille < 166 && poids >= 54 && poids <= 59
   || taille >= 145 && taille < 163 && poids >= 60 && poids <= 65)
{
    Console.WriteLine("Taille 1");
}
else if (taille >= 169 && taille < 183 && poids >= 48 && poids <= 53 ||
    taille >= 166 && taille < 178 && poids >= 54 && poids <= 59 ||
    taille >= 163 && taille < 175 && poids >= 60 && poids <= 65 ||
    taille >= 160 && taille < 172 && poids >= 66 && poids <= 71)
{
    Console.WriteLine("Taille 2");
}
else if (taille >= 178 && taille <=183 && poids >= 54 && poids <= 59
   || taille >= 175 && taille <= 183 && poids >= 60 && poids <= 65
   || taille >= 172 && taille <= 183 && poids >= 66 && poids <= 71
   || taille >= 163 && taille <= 183 && poids >= 72 && poids <= 77)
{
    Console.WriteLine("Taille 3");
} else
{
    Console.WriteLine("Aucune taille ne vous correspond !");
}