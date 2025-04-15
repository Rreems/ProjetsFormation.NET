using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo08Generiques.Tourneviss.Visses;

namespace Demo08Generiques.Tourneviss
{
    public class TournevisPlat : TournevisAEmbout<VisPlate>
    //public class TournevisPlat<T> : TournevisAEmbout<T> where T : Vis

    {
        // En héritant on spécifie le type ici
        // Possibilité d'ajouter des méthodes spécifiques pour les vis plates
    }

}
