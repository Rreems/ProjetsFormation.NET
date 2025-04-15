using M2i.Learning.CommandsConverters.Pages;

namespace M2i.Learning.CommandsConverters
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DemoCommandsPage();
        }
    }
}
