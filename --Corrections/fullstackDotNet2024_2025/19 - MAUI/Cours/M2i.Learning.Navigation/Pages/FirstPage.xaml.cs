namespace M2i.Learning.Navigation.Pages;

public partial class FirstPage : ContentPage
{
	public FirstPage()
	{
		InitializeComponent();
	}

    private void btnNextPage_Clicked(object sender, EventArgs e)
    {
		Navigation.PushAsync(new SecondPage(entryText.Text));
    }
}