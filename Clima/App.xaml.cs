using Clima.MVVM.Views;

namespace Clima;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new WeatherView();
	}
}

