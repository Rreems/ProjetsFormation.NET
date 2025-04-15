int[] tab = new int[10];

for (int i = 0; i < tab.Length; i++)
{
    Console.Write($"Veuillez saisir la valeur n°{i+1} : ");
    tab[i] = Convert.ToInt32(Console.ReadLine());
}

string espace = "";

for (int i = 0; i < tab.Length; i++)
{
    Console.WriteLine($"{espace}{tab[i]}");
    espace += "\t";
}