using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo13Linq;

public class Personne
{
    public string? Prenom { get; set; }
    public string? Nom { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public int Age { get; set; }

    public override string ToString() => $"Personne : {Prenom} {Nom} {Email} {Phone} {Age}";
    
}

