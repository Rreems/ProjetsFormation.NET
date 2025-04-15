using M2i.Learning.CommandsConverters.Models;
using M2i.Learning.CommandsConverters.ViewModels;

namespace M2i.Learning.CommandsConverters.Pages;

public partial class DemoCommandsPage : ContentPage
{
	public DemoCommandsPage()
	{
		InitializeComponent();
		BindingContext = new DemoCommandsViewModel();
	}

  //  private void btnResetCat_Clicked(object sender, EventArgs e)
  //  {
		//var vm = BindingContext as DemoCommandsViewModel;
		//if (vm == null) return;
		//vm.Cat = new Cat()
		//{
		//	Name = "Berlioz",
		//	Breed = "Siamese",
		//	Color = "Beige"
		//};
  //  }
}