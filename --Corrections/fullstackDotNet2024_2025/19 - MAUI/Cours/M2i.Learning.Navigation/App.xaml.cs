using M2i.Learning.Navigation.Pages;

namespace M2i.Learning.Navigation
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new FirstPage());
        }
    }
}
