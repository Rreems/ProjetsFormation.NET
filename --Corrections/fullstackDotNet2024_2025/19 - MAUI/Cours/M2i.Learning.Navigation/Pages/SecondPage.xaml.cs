using M2i.Learning.Navigation.ViewModels;

namespace M2i.Learning.Navigation.Pages;

public partial class SecondPage : ContentPage
{
	public SecondPage(string text)
	{
		InitializeComponent();
        BindingContext = new SecondViewModel() { Text = text };
	}

    private void btnPreviousPage_Clicked(object sender, EventArgs e)
    {
        Navigation.PopAsync();
    }

    private void btnNextPage_Clicked(object sender, EventArgs e)
    {
        var vm = BindingContext as SecondViewModel;
        var leTexteDuVm = vm.Text;
        Navigation.PushAsync(new ThirdPage() 
        { 
            BindingContext = new ThirdViewModel() 
            { 
                Text = leTexteDuVm
            } 
        });
    }
}