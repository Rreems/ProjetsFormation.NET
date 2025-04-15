using Exercice05.Models;

namespace Exercice05.Data
{
    public class FakeDb
    {
        public HashSet<Marmoset> Marmosets { get; } = new()
        {
            new Marmoset()
            {
                Id = 1L,
                Name = "Tutu",
                Color = "Beige",
                Age = 12
            }
        };
    }
}
