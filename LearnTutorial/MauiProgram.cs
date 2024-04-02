using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace LearnTutorial
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

            //For the observation Repository
            string dbPath = FileAccessHelper.GetLocalFilePath("observations.db3");//this is it's own class
            builder.Services.TryAddSingleton<ObservationRepository>(s => ActivatorUtilities.CreateInstance<ObservationRepository>(s, dbPath));


#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
