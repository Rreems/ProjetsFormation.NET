namespace Demo02TDD.Core;

public class RechercheVille
{
    private List<string> _villes;

    public RechercheVille(List<string> villes)
    {
        _villes = villes;
    }

    public List<string> Rechercher(string mot)
    {
        //if (mot == "*")
        //    return _villes;
        //if (mot.Length < 2)
        //    throw new NotFoundException();
        //else
        //    //return _villes.Where(v => v.StartsWith(mot)).ToList();
        //    //return _villes.Where(v => v.ToLower().StartsWith(mot.ToLower())).ToList();
        //    return _villes.Where(v => v.ToLower().Contains(mot.ToLower())).ToList();
        //throw new NotImplementedException();

        // Version Refacto finale
        //if (mot == "*")
        //    return _villes;
        //if (mot.Length < 2)
        //    throw new NotFoundException();
        //return _villes.Where(v => v.ToLower().Contains(mot.ToLower())).ToList();


        // Version avec un switch-expression
        return mot.Length switch
        {
            _ when mot == "*" => _villes,
            < 2 => throw new NotFoundException(),
            >= 2 => _villes.Where(v => v.Contains(mot, StringComparison.InvariantCultureIgnoreCase)).ToList()
        };
    }
}
