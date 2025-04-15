using M2i.Learning.WeatherApp.Views;

namespace M2i.Learning.WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new StartView();
        }
    }
}
