using System.Diagnostics;

namespace Exo01.Layout;

public partial class DemoStackLayout : ContentPage
{
    public DemoStackLayout()
    {
        InitializeComponent();
        entryA.Text = "Quelque chose..";
    }

    private void entryA_Completed(object sender, EventArgs e)
    {

        // 1e solution pour récupérer valeur de mon Entry:
        //Debug.WriteLine(entryA.Text);

        //2e solution:
        var entry = (Entry)sender;
        if (entry != null)
        {
            Debug.WriteLine(entry.Text);
        }

    }

    private void myButton_Clicked(object sender, EventArgs e)
    {
        entryA.Text += "J'ai cliqué zut...";
        displayLabel.Text = entryA.Text;

        var nouvelleColor = Color.FromArgb("#ff862f");

        displayLabel.BackgroundColor = nouvelleColor;
    }

    private void maCheckbox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {

    }

    private void leSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {

    }

    private void leStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {

    }

    private void leSwitch_Toggled(object sender, ToggledEventArgs e)
    {

    }

    private void maDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        //DisplayAlert(`Titre alert`, `a` , );


    }

    private void monTimePicker_TimeSelected(object sender, TimeChangedEventArgs e)
    {

    }
}