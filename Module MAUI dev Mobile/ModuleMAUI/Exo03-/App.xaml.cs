using Exo03_.Pages;

namespace Exo03_
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

            return new Window(new CitationPage());
        }
    }
}