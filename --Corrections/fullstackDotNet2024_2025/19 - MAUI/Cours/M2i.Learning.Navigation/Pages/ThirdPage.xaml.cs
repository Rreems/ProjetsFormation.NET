using M2i.Learning.Navigation.ViewModels;

namespace M2i.Learning.Navigation.Pages;

public partial class ThirdPage : ContentPage
{
	public ThirdPage()
	{
		InitializeComponent();
        BindingContext = new ThirdViewModel();
	}

    private void btnRootPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PopToRootAsync();
    }

    private void btnPreviousPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }
}