using CommunityToolkit.Maui;
using Debt_Book.Services;
using Debt_Book.Viewmodels;
using Microsoft.Extensions.Logging;

namespace Debt_Book
{
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
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<AddDebtorViewModel>();
            builder.Services.AddTransient<DebtorDetailsViewModel>();

            return builder.Build();
        }
    }
}
