using acabreraS5.Utils;
using Microsoft.Extensions.Logging;

namespace acabreraS5
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            string dbpath = FileAccessHelper.GetLocalFilePath("personas.db3");
            builder.Services.AddSingleton<personRepository>(s => ActivatorUtilities.CreateInstance<personRepository>(s, dbpath));

            return builder.Build();
        }
    }
}
