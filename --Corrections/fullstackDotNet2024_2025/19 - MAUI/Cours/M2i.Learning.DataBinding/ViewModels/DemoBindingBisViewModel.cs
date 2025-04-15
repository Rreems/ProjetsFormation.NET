using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using M2i.Learning.DataBinding.Models;

namespace M2i.Learning.DataBinding.ViewModels
{
    public class DemoBindingBisViewModel
    {
        public HashSet<Cat> Cats { get; set; } = [
            new(),
            new() { Name="Caramel", Breed="Persan", Color="Beige" },
            new() { Name="Popeye", Breed="Russian Blue", Color="Grey" }
            ];
    }
}
