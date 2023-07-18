using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;

namespace FlagGuesser;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Roboto-Thin.ttf", "RobotoThin");
				fonts.AddFont("Roboto-Bold.ttf", "RobotoBold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
