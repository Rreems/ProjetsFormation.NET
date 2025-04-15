namespace M2i.Exercices.ColorMaker
{
    public partial class MainPage : ContentPage
    {
        int redValue;
        int greenValue;
        int blueValue;

        public MainPage()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            // On récupère les couleurs contenues dans les sliders
            redValue = Convert.ToInt32(redSlider.Value);
            greenValue = Convert.ToInt32(greenSlider.Value);
            blueValue = Convert.ToInt32(blueSlider.Value);

            UpdateDisplay();
        }

        private void rndColorButton_Clicked(object sender, EventArgs e)
        {
            // On génère une instance de Random
            var rnd = new Random();

            // On s'en sert pour générer trois valeurs entières aléatoires 
            redValue = rnd.Next(256);
            redSlider.Value = redValue;
            greenValue = rnd.Next(256);
            greenSlider.Value = greenValue;
            blueValue = rnd.Next(256);
            blueSlider.Value = blueValue;

            UpdateDisplay();
        }

        private void UpdateDisplay()
        {
            // On met à jour l'affichage des labels de slider
            redLabel.Text = $"Red value: {redValue}";
            greenLabel.Text = $"Green value: {greenValue}";
            blueLabel.Text = $"Blue value: {blueValue}";

            // On génère un objet de type Color via les valeurs de couleurs
            var nouvelleCouleur = Color.FromRgb(redValue, greenValue, blueValue);

            // On modifie les couleurs de fond des éléments
            gridContainer.BackgroundColor = nouvelleCouleur;
            squareDisplay.Fill = nouvelleCouleur;

            // On modifie le label pour afficher la valeur hexadécimale de notre couleur
            hexValueLabel.Text = $"Hex value: {nouvelleCouleur.ToHex()}";
        }
    }

}
