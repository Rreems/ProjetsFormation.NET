using System.Diagnostics;
using System.Threading.Tasks;
using M2i.LEarning.Pendu.ViewModels;

namespace M2i.LEarning.Pendu
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new MainViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();

            var vm = BindingContext as MainViewModel;
            vm.NewGame();
            EnableAllButtons();
        }

        private void EnableAllButtons()
        {
            foreach (var child in flxLaytLetterButtons.Children)
            {
                var currentBtn = child as Button;
                currentBtn.IsEnabled = true;
            }
        }

        private void DisableAllButtons()
        {
            foreach (var child in flxLaytLetterButtons.Children)
            {
                var currentBtn = child as Button;
                currentBtn.IsEnabled = false;
            }
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("mots.txt");
            using var reader = new StreamReader(stream);

            var tmpList = new List<string>();

            while(reader.Peek() >= 0)
            {
                var currentLine = await reader.ReadLineAsync();
                if (!string.IsNullOrEmpty(currentLine)) tmpList.Add(currentLine);
            }

            var vm = BindingContext as MainViewModel;
            vm.Words = tmpList;
        }

        private void btnLetter_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;
            button.IsEnabled = false;
            var letter = button.Text[0];

            var vm = BindingContext as MainViewModel;
            vm.TestChar(letter);
            if(vm.ErrorCount >= 7)
            {
                stckLaytWinStatus.IsVisible = true;
                lblWin.Text = "You lost!";
                DisableAllButtons();
            } else if (vm.TestWin())
            {
                stckLaytWinStatus.IsVisible = true;
                lblWin.Text = "You won!";
                DisableAllButtons();
            }
        }

        private void btnRetry_Clicked(object sender, EventArgs e)
        {
            var vm = BindingContext as MainViewModel;
            vm.NewGame();
            stckLaytWinStatus.IsVisible = false;
            EnableAllButtons();
        }
    }

}
