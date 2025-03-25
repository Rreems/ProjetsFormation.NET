using System.Diagnostics;
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace Exo02_Pourboires.Pages;

public partial class PourboirePage : ContentPage
{

    private decimal ValeurFacture = 0;

    private decimal ValeurTotal { get; set; } = 0;

    private int TauxPourboire { get; set; } = 10;
    private int NombrePersonne { get; set; } = 1;

    public PourboirePage()
    {
        InitializeComponent();
    }

    private void factureValueEntry_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (Decimal.TryParse(e.NewTextValue, out ValeurFacture))
        {
            updateDisplay();
        }
    }

    private void DixPourboireButton_Clicked(object sender, EventArgs e)
    {
        TauxPourboire = 10;
        updateDisplay();
    }

    private void QuinzePourboireButton_Clicked(object sender, EventArgs e)
    {
        TauxPourboire = 15;
        updateDisplay();
    }

    private void VingtPourboireButton_Clicked(object sender, EventArgs e)
    {
        TauxPourboire = 20;
        updateDisplay();
    }

    private void pourboireSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        double taux = pourboireSlider.Value;
        TauxPourboire = (int) Math.Round(taux, 0);
        updateDisplay();
    }

    private void removePersonneButton_Clicked(object sender, EventArgs e)
    {
        if (NombrePersonne > 1)
        {
            NombrePersonne--;
            updateDisplay();
        }

    }
    private void addPersonneButton_Clicked(object sender, EventArgs e)
    {
        NombrePersonne++;
        updateDisplay();
    }

    private void updateDisplay()
    {
        decimal tauxPourb = TauxPourboire;


        ValeurTotal = Math.Round((ValeurFacture * (1 + tauxPourb / 100)) / NombrePersonne , 2);


        pourboireSlider.Value = TauxPourboire;

        pouboireSliderLabel.Text = $"Pourboire ({TauxPourboire}%) :";

        facturePersonnelleLabel.Text = ValeurTotal.ToString("C", new CultureInfo("fr-FR"))  + " €";

        sousTotalValueLabel.Text = ValeurFacture + " €";

        pourboireValueLabel.Text = TauxPourboire + "%";

        nomberPersonneLabel.Text = NombrePersonne.ToString();
    }
}
