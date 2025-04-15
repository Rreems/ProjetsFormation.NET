using M2i.Learning.DataBinding.Models;
using M2i.Learning.DataBinding.ViewModels;

namespace M2i.Learning.DataBinding.Pages;

public partial class DemoBindingFieldPage : ContentPage
{
    //public Person JDupont { get; set; }
    public DemoBindingFieldPage()
	{
		InitializeComponent();

		//JDupont = new Person();

		//BindingContext = JDupont;
		BindingContext = new DemoBindingFieldViewModel();
	}
}