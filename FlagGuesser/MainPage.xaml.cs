using FlagGuesser.Flags;

namespace FlagGuesser;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
    }

	async void OnClickIntro(object sender, EventArgs e)
	{
        await Shell.Current.GoToAsync("MenuPage");
    }
}

