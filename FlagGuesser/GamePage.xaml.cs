using FlagGuesser.Flags;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Shapes;
using Microsoft.Maui.Controls.Xaml;

namespace FlagGuesser;

public partial class GamePage : ContentPage
{
	public static int difficulty = 1;
    static int correctAnswer;
    
	public GamePage()
	{
		InitializeComponent();
        BindingContext = new FlagsView();
        generateRandomFlags();
    }

    void generateRandomFlags()
    {
        Random rng = new Random();
        int[] tab = new int[4];

        do
        {
            for(int i = 0; i < 4; i++)
                tab[i] = rng.Next(0, FlagsView.flags.Count());
        }
        while (!checkForUnique(tab));

        countryFlag1.Source = FlagsView.flags[tab[0]].flag;
        countryFlag2.Source = FlagsView.flags[tab[1]].flag;
        countryFlag3.Source = FlagsView.flags[tab[2]].flag;
        countryFlag4.Source = FlagsView.flags[tab[3]].flag;

        int x = rng.Next(0, 4);
        correctAnswer = x;
        CountryName.Text = FlagsView.flags[tab[x]].country;
    }
	void guess(int x)
	{
        Rectangle[] tiles = { tile1, tile2, tile3, tile4, tile5, tile6, tile7, tile8, tile9};
        bool found = false;

        //Looking for empty tile to color
        foreach (Rectangle tile in tiles)
        {
            if (tile.BackgroundColor.ToHex() == "#222222")
            {
                if (x == correctAnswer)
                    tile.BackgroundColor = Color.FromArgb("#2EFF2E");
                else
                    tile.BackgroundColor = Color.FromArgb("#FF2E2E");
                found = true;
                break;
            }
        }

        //Color change on tiles (backwards)
        if (!found)
        {
            int i = 1;
            foreach (Rectangle tile in tiles)
            {
                tile.BackgroundColor = tiles[i].BackgroundColor;
                i++;
                
                if(i == 9)
                {
                    if (x == correctAnswer)
                        tiles[8].BackgroundColor = Color.FromArgb("#2EFF2E");
                    else
                        tiles[8].BackgroundColor = Color.FromArgb("#FF2E2E");
                    break;
                }
            }
        }

        generateRandomFlags();
    }
    bool checkForUnique(int[] tab)
    {
        if (tab[0] != tab[1] && tab[0] != tab[2] && tab[0] != tab[3] && tab[1] != tab[2] && tab[1] != tab[3] && tab[2] != tab[3])
        {
            for (int i = 0; i < 4; i++)
            {
                if (FlagsView.flags[tab[i]].difficulty > difficulty)
                    return false;
            }
            return true;
        }
        return false;
    }

	void Choice1(object sender, EventArgs e)
	{
		guess(0); 
	}
    void Choice2(object sender, EventArgs e)
    {
        guess(1);
    }
    void Choice3(object sender, EventArgs e)
    {
        guess(2);
    }
    void Choice4(object sender, EventArgs e)
    {
        guess(3);
    }
}