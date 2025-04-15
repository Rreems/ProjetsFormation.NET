using M2i.Learning.CommandsConverters.ViewModels;

namespace M2i.Learning.CommandsConverters.Pages;

public partial class StartPage : ContentPage
{
	public StartPage()
	{
		InitializeComponent();
		BindingContext = new StartViewModel();
	}
}