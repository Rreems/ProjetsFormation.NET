//int CompteurDeLettreA(string chaine)
//{
//    int compteurA = 0;
//    foreach(char c in chaine.ToLower())
//    {
//        if (c == 'a')
//        {
//            compteurA++;
//        }
//    }
//    return compteurA;
//}

int CompteurDeLettreA(string chaine)
{
    return chaine.ToLower().Count(c => c == 'a');
}

Console.WriteLine(CompteurDeLettreA("C'est le b-a ba"));
Console.WriteLine(CompteurDeLettreA("mixer"));

