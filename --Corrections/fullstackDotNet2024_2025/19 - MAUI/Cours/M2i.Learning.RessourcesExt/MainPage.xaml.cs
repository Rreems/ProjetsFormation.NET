namespace M2i.Learning.RessourcesExt
{
    public partial class MainPage : ContentPage
    {
        HashSet<string> ingredientsSet = new();
        public MainPage()
        {
            InitializeComponent();
        }

        // Cette méthode permet de se brancher au cycle de vie de la page (ici son apparition) et d'y faire s'exécuter du code
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            // On attend le chargement des assets
            await LoadMauiAsset();

            // On se sert de la liste d'ingrédients pour alimenter le label
            lblIngredient.Text = "Ingrédients: " + String.Join(", ", ingredientsSet);
        }

        async Task LoadMauiAsset()
        {
            // On charge l'élément sous forme de flux binaire
            using var stream = await FileSystem.OpenAppPackageFileAsync("courses.txt");
            using var reader = new StreamReader(stream);

            // On regarde si on est en fin de fichier ou pas (s'il y a encore des données à lire)
            while (reader.Peek() >= 0)
            {
                // Pour chaque ligne, on va ajouter le texte à notre Set de chaines de caractères
                var lineToAdd = await reader.ReadLineAsync();
                if (!String.IsNullOrEmpty(lineToAdd)) ingredientsSet.Add(lineToAdd);
            }
        }
    }

}
