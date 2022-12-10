namespace VinuezaValverdeVintimilla_P2;

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
                fonts.AddFont("Sitka.ttc", "Sitka");
                fonts.AddFont("Lobster-Regular.ttf", "Lobster");
            });

		return builder.Build();
	}
}
