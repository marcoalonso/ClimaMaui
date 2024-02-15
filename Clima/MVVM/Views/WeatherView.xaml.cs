using Clima.MVVM.ViewModels;

namespace Clima.MVVM.Views;

public partial class WeatherView : ContentPage
{
	public WeatherView()
	{
		InitializeComponent();
		BindingContext = new WeatherViewModel();

    }
}
