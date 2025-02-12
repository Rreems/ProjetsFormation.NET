using Exo04.Models;

namespace Exo04.Data;

public class FakeDb
{
    public readonly HashSet<Marsupilami> Marsupilamis = new()
    {
        new Marsupilami() { Id = 1, PetitNom= "Houba", Couleur= "Jaune à points noirs"},
        new Marsupilami() { Id = 2, PetitNom= "Booba Doubla", Couleur = "Noir à points jaunes"},
        new Marsupilami() { Id = 3, PetitNom= "Houba Houba, fils de Booba Doubla", Couleur = "Noir mat"}
    };
}
