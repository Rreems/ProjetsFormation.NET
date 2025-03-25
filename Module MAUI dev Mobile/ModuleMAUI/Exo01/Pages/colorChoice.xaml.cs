using System.Diagnostics;

namespace Exo01.Pages;

public partial class ColorChoice : ContentPage
{

    private int RedValue { get; set; } = 255;
    private int GreenValue { get; set; } = 255;
    private int BlueValue { get; set; } = 255;
    private string HexaColor { get; set; } = "#FFFFFF";

    

	public ColorChoice()
	{
		InitializeComponent();
	}

	private void redSlider_ValueChanged(object sender, ValueChangedEventArgs e)
	{
         RedValue = (int) Math.Round(redSlider.Value, 0);

        redLabel.Text = $"Red value: {RedValue.ToString()}";

        Debug.WriteLine("Valeur Red hexa:" + RedValue.ToString("X2"));

        HexaColor = HexaColor.Substring(0, 1) + RedValue.ToString("X2") + HexaColor.Substring(3);

        Debug.WriteLine("Hexacc:" + HexaColor);

        hexLabel.Text = "HEX Value :" + HexaColor;

        rectangleColor.Fill = Color.FromArgb(HexaColor);
        

        contentPage.BackgroundColor = Color.FromArgb(HexaColor);

    }

    private void greenSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        greenLabel.Text = $"Green value: {Math.Round(greenSlider.Value, 0).ToString()}";

        GreenValue = (int)Math.Round(greenSlider.Value, 0);

        greenLabel.Text = $"Green value: {GreenValue.ToString()}";


        HexaColor = HexaColor.Substring(0, 3) + GreenValue.ToString("X2") + HexaColor.Substring(5);


        hexLabel.Text = "HEX Value :" + HexaColor;

        rectangleColor.Fill = Color.FromArgb(HexaColor);

        contentPage.BackgroundColor = Color.FromArgb(HexaColor);
    }

    private void blueSlider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        blueLabel.Text = $"Blue value: {Math.Round(blueSlider.Value, 0).ToString()}";


        BlueValue = (int)Math.Round(blueSlider.Value, 0);

        blueLabel.Text = $"Blue value: {BlueValue.ToString()}";


        HexaColor = HexaColor.Substring(0, 5) + BlueValue.ToString("X2");


        hexLabel.Text = "HEX Value :" + HexaColor;

        rectangleColor.Fill = Color.FromArgb(HexaColor);

        contentPage.BackgroundColor = Color.FromArgb(HexaColor);
    }

    private void randomColorButton_Clicked(object sender, EventArgs e)
    {

        RedValue = new Random().Next(1, 256);
        GreenValue = new Random().Next(1, 256);
        BlueValue = new Random().Next(1, 256);

        blueSlider.Value = BlueValue;
        greenSlider.Value = GreenValue;
        redSlider.Value = RedValue;

        HexaColor = "#" + RedValue.ToString("X2") + GreenValue.ToString("X2") + BlueValue.ToString("X2");

        rectangleColor.BackgroundColor = Color.FromArgb(HexaColor);
        rectangleColor.Stroke = Color.FromArgb(HexaColor);

        contentPage.BackgroundColor = Color.FromArgb(HexaColor);
    }
}