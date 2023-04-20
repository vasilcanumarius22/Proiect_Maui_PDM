using MAUI_PROJECT_PDM.Views;

namespace MAUI_PROJECT_PDM;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new NavigationPage(new Login());

    }
}
