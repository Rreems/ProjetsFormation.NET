Console.Write("Veuillez saisir le prix HT (en euros) : ");
double prixHT = Convert.ToDouble(Console.ReadLine());

Console.Write("Veuillez saisir le taux (en %) : ");
double tva = Convert.ToDouble(Console.ReadLine()); // / 100

double montantTva = prixHT * tva / 100;
Console.WriteLine($"Le montant de la tva est de {montantTva} euros");
Console.WriteLine($"Le prix TTC est de {prixHT + montantTva} euros");