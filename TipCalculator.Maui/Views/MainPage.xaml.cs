using TipCalculator.Maui.ViewModels;
using TipCalculator.Maui.Views;

namespace TipCalculator.Maui.Views;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
		BindingContext = new MainViewModel();
	}
}
