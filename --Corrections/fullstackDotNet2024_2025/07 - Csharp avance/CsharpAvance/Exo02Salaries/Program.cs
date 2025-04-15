using Exo02Salaries.Classes;

List<Salarie> salaries = new List<Salarie>
{
    new Salarie("001", "Chloé", "Comptabilité", "Cadre", 24000),
    new Salarie("002", "Emma", "Comptabilité", "Employée", 30000),
    new Salarie("003", "Georges", "Developpement", "Employé", 26000),
    new Salarie(),
};

foreach (Salarie salarie in salaries)
{
    salarie.AfficherSalaire();
}


Console.WriteLine("Nombre de salariés : " + Salarie.NombreSalaries);
Console.WriteLine("Salaire total : " + Salarie.TotalSalaires);

Console.WriteLine("On change le salaire de Chloé à 500000.");
salaries[0].Salaire = 500000;

Console.WriteLine("Nombre de salariés : " + Salarie.NombreSalaries);
Console.WriteLine("Salaire total : " + Salarie.TotalSalaires);

Console.WriteLine("Remise à zéro des salariés et salaire total.");
Salarie.RemiseAZero();

Console.WriteLine("Nombre de salariés : " + Salarie.NombreSalaries);
Console.WriteLine("Salaire total : " + Salarie.TotalSalaires);