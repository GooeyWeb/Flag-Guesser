namespace FlagGuesser;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
	}

    async void Easy(object sender, EventArgs e)
    {
        GamePage.difficulty = 1;
        await Shell.Current.GoToAsync("GamePage");
    }

    async void Medium(object sender, EventArgs e)
    {
        GamePage.difficulty = 2;
        await Shell.Current.GoToAsync("GamePage");
    }

    async void Hard(object sender, EventArgs e)
    {
        GamePage.difficulty = 3;
        await Shell.Current.GoToAsync("GamePage");
    }
}