using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PropertyChanged;

namespace M2i.Learning.CommandsConverters.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Cat
    {
        public string Name { get; set; }
        public string Breed { get; set; }
        public string Color { get; set; }
    }
}
