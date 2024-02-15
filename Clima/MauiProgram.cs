﻿using Microsoft.Extensions.Logging;

namespace Clima;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Rubik-Light.ttf", "RubikLight");
                fonts.AddFont("Rubik-Regular.ttf", "Rubik");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

