using Exo02_Pourboires.Pages;

namespace Exo02_Pourboires
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            //return new Window(new AppShell());
            return new Window(new PourboirePage());
        }
    }
}