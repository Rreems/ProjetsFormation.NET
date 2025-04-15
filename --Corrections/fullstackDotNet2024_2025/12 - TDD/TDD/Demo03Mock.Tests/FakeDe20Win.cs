using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo03Mock.Tests
{
    /// <summary>
    /// Dé pipé pour toujours gagner au Jeu
    /// </summary>
    public class FakeDe20Win : IDe
    {
        public int Lancer()
        {
            return 20;
        }
    }
}
