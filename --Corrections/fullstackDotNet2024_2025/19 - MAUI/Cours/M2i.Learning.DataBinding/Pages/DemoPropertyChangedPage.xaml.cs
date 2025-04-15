using M2i.Learning.DataBinding.ViewModels;

namespace M2i.Learning.DataBinding.Pages;

public partial class DemoPropertyChangedPage : ContentPage
{
	public DemoPropertyChangedPage()
	{
		InitializeComponent();
		BindingContext = new DemoPropertyChangedViewModel();
	}
}