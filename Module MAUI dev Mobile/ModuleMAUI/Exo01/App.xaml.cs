using Exo01.Layout;
using Exo01.Pages;

namespace Exo01
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {

            //return new Window(new TabbedPageDemoo());
            //return new Window(new DemoLayoutPage());
            //return new Window(new DemoStackLayout());
            //return new Window(new DemoGridLayout());
            //return new Window(new DemoFlexLayout());
            //return new Window(new DemoAbsoluteLayout());

            //return new Window(new DemoStackLayout()); // -> Démos des Controles

            return new Window(new ColorChoice());
        }
    }
}