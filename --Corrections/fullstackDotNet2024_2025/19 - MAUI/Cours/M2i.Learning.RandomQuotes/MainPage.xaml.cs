namespace M2i.Learning.RandomQuotes
{
    public partial class MainPage : ContentPage
    {
        //HashSet<string> _quotesHashSet = new();
        List<string> _quotesList = new();
        Random rnd = new();

        public MainPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await LoadMauiAsset();

            UpdateDisplay();
        }

        private void btnRdnQuote_Clicked(object sender, EventArgs e)
        {
            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            var rndIndex = rnd.Next(_quotesList.Count);
            lblQuote.Text = _quotesList[rndIndex];

            grdStart.Color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            grdEnd.Color = Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }

        async Task LoadMauiAsset()
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
            using var reader = new StreamReader(stream);

            while (reader.Peek() >= 0) 
            {
                var currentLine = await reader.ReadLineAsync();
                if (!String.IsNullOrWhiteSpace(currentLine)) _quotesList.Add(currentLine);
            }
        }
    }

}
