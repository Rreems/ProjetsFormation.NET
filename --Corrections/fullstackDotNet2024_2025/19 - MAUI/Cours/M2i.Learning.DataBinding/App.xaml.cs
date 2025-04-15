using M2i.Learning.DataBinding.Pages;

namespace M2i.Learning.DataBinding
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new DemoPropertyChangedPage();
        }
    }
}
