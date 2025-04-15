using M2i.Learning.WeatherApp.ViewModels;

namespace M2i.Learning.WeatherApp.Views;

public partial class StartView : ContentPage
{
	public StartView()
	{
		InitializeComponent();
		BindingContext = new StartViewModel();
	}
}