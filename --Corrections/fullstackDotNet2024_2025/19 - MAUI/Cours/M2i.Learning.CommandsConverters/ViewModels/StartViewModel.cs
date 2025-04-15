using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace M2i.Learning.CommandsConverters.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class StartViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
        public int Age { get; set; }
        public double Height { get; set; }
    }
}
