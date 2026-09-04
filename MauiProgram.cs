using Microsoft.Extensions.Logging;
using ProductosApp_Q32026.Services;
using ProductosApp_Q32026.ViewModels;
using ProductosApp_Q32026.Views;

namespace ProductosApp_Q32026;

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
			});

		// Una sola conexion a la base de datos
		builder.Services.AddSingleton<ProductoService>();

		// Transient
		builder.Services.AddTransient<ProductoViewModel>();
		builder.Services.AddTransient<ProductoView>();

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
