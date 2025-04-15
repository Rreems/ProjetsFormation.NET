Console.Write("Veuillez saisir le capital de départ : ");
double capitalDepart = Convert.ToDouble(Console.ReadLine());

Console.Write("Veuillez saisir le taux (en %) : ");
double taux = Convert.ToDouble(Console.ReadLine()) / 100;

Console.Write("Veuillez saisir la durée de l'épargne : ");
double temps = Convert.ToDouble(Console.ReadLine());

double montantInterets = capitalDepart * Math.Pow(1 + taux, temps) - capitalDepart;
double capitalFinal = capitalDepart + montantInterets;

Console.WriteLine($"Le montant des intérets sera de {Math.Round(montantInterets, 2)} euros après {temps} ans");
Console.WriteLine($"Le capital final sera de {Math.Round(capitalFinal,2)} euros");