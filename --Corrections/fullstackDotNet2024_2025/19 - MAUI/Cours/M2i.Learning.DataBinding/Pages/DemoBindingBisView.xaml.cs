using M2i.Learning.DataBinding.ViewModels;

namespace M2i.Learning.DataBinding.Pages;

public partial class DemoBindingBisView : ContentPage
{
	public DemoBindingBisView()
	{
		InitializeComponent();
		BindingContext = new DemoBindingBisViewModel();
	}
}