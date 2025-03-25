using Exo04_.Pages;
using Exo04_JeuDuPendu.Pages;

namespace Exo04_JeuDuPendu
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();

            //MainPage = new PenduPage();

            MainPage = new WeatherPage();
        }
    }
}
