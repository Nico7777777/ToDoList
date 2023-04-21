using Tema2.Views;

namespace Tema2;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(BinPage), typeof(BinPage));
		//Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
	}
}
