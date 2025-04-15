Console.WriteLine("Combien de nombres contiendra le tableau ? ");
int nb = Convert.ToInt32(Console.ReadLine());
int[] tab = new int[nb];

Console.WriteLine("Affectation automatique des valeurs...");

Random random = new Random();

for (int i = 0; i < tab.Length; i++)
{
    tab[i] = random.Next(1, 51);
}

for (int i = 0; i < tab.Length; i++)
{
    //string estPair = tab[i] % 2 == 0 ? "pair" : "impair";
    Console.WriteLine($"Le nombre {tab[i]} est {(tab[i] % 2 == 0 ? "pair" : "impair")}");
}