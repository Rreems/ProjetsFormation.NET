string NomComplet(string prenom, string nom)
{
    return $"{prenom} {nom}";
}

string nomPrenom = NomComplet("Benoit", "Lecoeuvre");
Console.WriteLine(nomPrenom);

Console.WriteLine(NomComplet("Guillaume", "Mairesse"));