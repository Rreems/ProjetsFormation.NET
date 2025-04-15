int year0 = 2015;
double taux = 0.0089;
double pop = 96809;
int popMax = 120000;
int year = 0;

while (pop < popMax)
{
    pop += pop * taux;
    year++;
}

//for (year = 0; pop < popMax; year++)
//{
//    pop += pop * taux;
//}

Console.WriteLine($"Il faudra {year} ans pour atteindre les 120000 habitants. Nous serons en {year0 + year}");