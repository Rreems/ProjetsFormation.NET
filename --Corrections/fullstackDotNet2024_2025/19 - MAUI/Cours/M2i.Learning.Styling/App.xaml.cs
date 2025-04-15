using M2i.Learning.Styling.Pages;

namespace M2i.Learning.Styling
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SecondPage();
        }
    }
}
