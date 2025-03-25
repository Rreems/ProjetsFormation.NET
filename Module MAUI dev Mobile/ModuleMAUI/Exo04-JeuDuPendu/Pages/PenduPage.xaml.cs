using System.Diagnostics;
using System.Linq;
using Exo04_JeuDuPendu.ViewModels;
using Microsoft.Maui.Controls;

namespace Exo04_.Pages;

public partial class PenduPage : ContentPage
{
    private int nbEssaisRestants;
    private bool isWin;
    private string lettresProposees;
    private string motReponse;

    public void initGame()
    {
        nbEssaisRestants = 7;
        isWin = false;
        lettresProposees = "";
        motReponse = "MAUI";

    }

    public PenduPage()
    {
        InitializeComponent();

        initGame();

        BindingContext = new AlphabetViewModel();
    }


    private void btnLetter_Clicked(object sender, EventArgs e)
    {
        if (!isWin)
        {

            var button = sender as Button;
            if (button == null) return;
            var letter = button.Text;
            Debug.WriteLine(letter);

            button.IsEnabled = false;

            penduMain(letter[0]);
        }
    }

    private void ButtonRetry_Clicked(object sender, EventArgs e)
    {
        initGame();

    }

    public void displayPendu()
    {

    }
    public void displayReponse()
    {

    }

    private void penduMain(char c)
    {
        if (motReponse.Contains(c))
        {
            lettresProposees += c;
            displayReponse();
        }
        else
        {
            nbEssaisRestants--;

            displayPendu();
        }
    }

}