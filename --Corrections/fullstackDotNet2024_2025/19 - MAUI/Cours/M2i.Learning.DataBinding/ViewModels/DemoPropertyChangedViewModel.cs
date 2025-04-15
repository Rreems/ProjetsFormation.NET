using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace M2i.Learning.DataBinding.ViewModels
{
    class DemoPropertyChangedViewModel : INotifyPropertyChanged
    {
        private string text;

        public string NomProp { get; set; }

        public string TextBaseProp { get => text; set => text = value; }

        //Console.Write(TextBaseProp);
        //TextBaseProp = "Nouvelle valeur";

        public string Text 
        {
            get => text;
            set
            {
                text = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //protected void OnPropertyChanged(string propertyName = null)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
