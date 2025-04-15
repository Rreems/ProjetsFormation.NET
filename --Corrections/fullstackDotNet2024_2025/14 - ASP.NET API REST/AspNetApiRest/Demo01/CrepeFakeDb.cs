using Demo01.Models;

namespace Demo01
{
    public class CrepeFakeDb
    {
        public List<Crepe> Crepes { get; set; } = new List<Crepe>()
        {
            new Crepe()
            {
                Id = 1,
                Name = "Surprise du chef",
                Diameter = 14,
                IsSalty = true,
                Topping1 = Topping.Camembert,
                Topping2 = Topping.MappleSirup
            },
            new Crepe()
            {
                Id = 2,
                Name = "Fruits de la mer",
                Diameter = 14,
                IsSalty = true,
                Topping1 = Topping.Surimi,
                Topping2 = Topping.Nutella
            },
            new Crepe()
            {
                Id = 3,
                Name = "Double nut",
                Diameter = 14,
                IsSalty = false,
                Topping1 = Topping.Nutella,
                Topping2 = Topping.Nutella
            },
            new Crepe()
            {
                Id = 4,
                Name = "Myrtille",
                Diameter = 14,
                IsSalty = false,
                Topping1 = Topping.BlueBerryJam,
                Topping2 = Topping.BlueBerryJam
            },
        };
    }
}
