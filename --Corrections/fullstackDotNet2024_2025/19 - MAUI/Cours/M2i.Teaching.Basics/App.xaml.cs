using M2i.Teaching.Basics.Controls;
using M2i.Teaching.Basics.Layouts;
using M2i.Teaching.Basics.Pages;

namespace M2i.Teaching.Basics
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DemoControlsPage();
        }
    }
}
