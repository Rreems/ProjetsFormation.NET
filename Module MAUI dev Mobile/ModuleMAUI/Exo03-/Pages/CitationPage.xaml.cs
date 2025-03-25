using System.Diagnostics;
using System.Net;
using Microsoft.Maui.Controls;

namespace Exo03_.Pages;

public partial class CitationPage : ContentPage
{
    HashSet<string> quotesSet = new();

    public CitationPage()
    {
        InitializeComponent();

    }

    // Cette méthode permet de se brancher au cycle de vie de la page (ici son apparition) et d'y faire s'exécuter du code
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // On attend le chargement des assets
        await LoadMauiAsset();

        // On se sert de la liste de quote pour alimenter le label
        DisplayAnotherQuote();
        QuoteLabel.Text = quotesSet.ElementAt(0);
    }



    async Task LoadMauiAsset()
    {
        // On charge l'élément sous forme de flux binaire
        using var stream = await FileSystem.OpenAppPackageFileAsync("quotes.txt");
        using var reader = new StreamReader(stream);

        // On regarde si on est en fin de fichier ou pas (s'il y a encore des données à lire)
        while (reader.Peek() >= 0)
        {
            // Pour chaque ligne, on va ajouter le texte à notre Set de chaines de caractères
            var lineToAdd = await reader.ReadLineAsync();
            if (!String.IsNullOrEmpty(lineToAdd)) quotesSet.Add(lineToAdd);
        }
    }

    private void AnotherQuoteButton_Clicked(object sender, EventArgs e)
    {
        DisplayAnotherQuote();
    }

    private void DisplayAnotherQuote()
    {
        Random rnd = new Random();

        QuoteLabel.Text = quotesSet.ElementAt(rnd.Next(quotesSet.Count));

        if (rnd.Next(2) == 1)
        {
            GradientStop1.Offset = (float)0.0;
            GradientStop2.Offset = (float)1.1;
            LinearBrush.StartPoint = new Point(0, 0);
            LinearBrush.EndPoint = new Point(1, 1);
        }
        else
        {
            GradientStop1.Offset = (float)1.0;
            GradientStop2.Offset = (float)0.1;
            LinearBrush.StartPoint = new Point(0, 1);
            LinearBrush.EndPoint = new Point(1, 0);
        }


        var color1 = "#" + rnd.Next(255).ToString("X2") + rnd.Next(255).ToString("X2") + rnd.Next(255).ToString("X2");
        var color2 = "#" + rnd.Next(255).ToString("X2") + rnd.Next(255).ToString("X2") + rnd.Next(255).ToString("X2");

        Debug.WriteLine("Color1: " + color1);
        Debug.WriteLine("Color2: " + color2);

        GradientStop1.Color = Color.FromArgb(color1);
        GradientStop2.Color = Color.FromArgb(color2);

    }
}