using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo02TDD.Core
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("Non trouvé !")
        {
        }
    }
}
