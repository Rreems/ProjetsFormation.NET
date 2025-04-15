using System.Diagnostics;

namespace M2i.Teaching.Basics.Controls;

public partial class DemoControlsPage : ContentPage
{
	public DemoControlsPage()
	{
		InitializeComponent();
	}

    private void entryA_Completed(object sender, EventArgs e)
    {
		//Debug.WriteLine(entryA.Text);

		var entry = sender as Entry;
		if (entry != null)
		{
			Debug.WriteLine(entry.Text);
		}

	}

    private void entryA_TextChanged(object sender, TextChangedEventArgs e)
    {
		Debug.WriteLine(e.NewTextValue);
    }

    private void leBouton_Clicked(object sender, EventArgs e)
    {
		entryA.Text = "Je viens de changer !";
        displayLabel.Text = "Je viens de changer !";
        var nouvelleCouleur = Color.FromHex("#a13a8e");
        displayLabel.BackgroundColor = nouvelleCouleur;
    }

    private void laCheckBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
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

    private void leDatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        var datePicker = sender as DatePicker;
        if (datePicker != null) {
            DisplayAlert("Titre de l'alerte", $"La Date: {datePicker.Date.ToLongDateString()}", "Valider");
        }
    }
}