using Microsoft.Extensions.Logging;
using MoneyManager.Services;

namespace MoneyManager
{
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
                });

            builder.Services.AddMauiBlazorWebView();

            //registering User Services
            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<IUserService, UserService>();
            builder.Services.AddSingleton<AuthenticationStateService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddSingleton<ITransactionService, TransactionService>();
           
            



#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
