Console.Write("Veuillez saisir la longueur du premier côté (en cm) : ");
double cote1 = Convert.ToDouble(Console.ReadLine());

Console.Write("Veuillez saisir la longueur du second côté (en cm) : ");
double cote2 = Convert.ToDouble(Console.ReadLine());

double hyp = Math.Sqrt(Math.Pow(cote1, 2) + Math.Pow(cote2, 2));

Console.WriteLine($"Hypothénuse : {Math.Round(hyp, 2)} cm");
