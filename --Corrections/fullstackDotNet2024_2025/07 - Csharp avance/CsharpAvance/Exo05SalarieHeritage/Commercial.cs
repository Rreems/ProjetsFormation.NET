
namespace Exo05SalarieHeritage;

internal class Commercial : Salarie
{
    public decimal ChiffreDAffaire { get; set; } = 0;
    public decimal CommissionPct { get; set; } = 0;
    public override decimal SalaireTotal => Salaire + (ChiffreDAffaire * CommissionPct / 100);

    public Commercial() : base()
    {
        Nom = "Commercial par défaut";
    }

    public Commercial(string matricule, string service, string catégorie, 
                      string nom, decimal salaire, decimal chiffreDAffaire, decimal commissionPct) 
                    : base(matricule, service, catégorie, nom, salaire)
    {
        ChiffreDAffaire = chiffreDAffaire;
        CommissionPct = commissionPct;
    }

    public override void AfficherSalaire()
    {
        //if (this.GetType().Name == "Commercial")
        //if (this.GetType().Name == nameof(Commercial))
        if (GetType() == typeof(Commercial))
            Console.WriteLine("Je suis commercial :");

        base.AfficherSalaire();
        //Console.WriteLine($"Le salaire avec commission de {Nom} est de {Salaire + (ChiffreDAffaire * CommissionPct / 100)} euros");
        Console.WriteLine($"Le salaire avec commission de {Nom} est de {SalaireTotal} euros");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, ChiffreDAffaire = {ChiffreDAffaire}, CommissionPct = {CommissionPct}";
    }
}
