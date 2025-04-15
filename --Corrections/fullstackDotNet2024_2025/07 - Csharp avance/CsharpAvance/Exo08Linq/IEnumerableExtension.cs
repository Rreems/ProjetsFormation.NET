using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Person = (int Id, string Name, int Age, string City);

namespace Exo08Linq
{
    internal static class IEnumerableExtension
    {
        // Extension de Méthode
        public static void Display(this IEnumerable<Person> people) => people.ToList().ForEach(t => Console.WriteLine(t));
    }
}
