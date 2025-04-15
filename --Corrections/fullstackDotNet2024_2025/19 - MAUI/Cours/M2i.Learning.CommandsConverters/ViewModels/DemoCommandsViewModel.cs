using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using M2i.Learning.CommandsConverters.Models;
using PropertyChanged;

namespace M2i.Learning.CommandsConverters.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public class DemoCommandsViewModel
    {
        public Cat Cat { get; set; } = new Cat();

        //public ICommand ResetCatCommand => new Command(() =>
        //{
        //    Cat = new Cat()
        //    {
        //        Name = "Berlioz",
        //        Breed = "Siamese",
        //        Color = "Beige"
        //    };
        //});

        //public ICommand ResetCatCommand => new Command(() => ResetCat("Toto"));

        public ICommand ResetCatCommand => new Command((text) =>
        {
            var textAsString = (string)text;
            ResetCat(textAsString);
        });

        //public ICommand ResetCatCommand => new Command(ResetCat);

        private void ResetCat()
        {
            Cat = new Cat()
            {
                Name = "Berlioz",
                Breed = "Siamese",
                Color = "Beige"
            };
        }
        
        private void ResetCat(string catName)
        {
            Cat = new Cat()
            {
                Name = catName,
                Breed = "Siamese",
                Color = "Beige"
            };
        }
    }
}
