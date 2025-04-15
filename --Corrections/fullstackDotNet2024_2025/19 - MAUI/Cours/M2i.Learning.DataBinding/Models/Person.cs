using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M2i.Learning.DataBinding.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "John";
        public string LastName { get; set; } = "DUPONT";
        public string Email { get; set; } = "j.dupont@example.com";
    }
}
