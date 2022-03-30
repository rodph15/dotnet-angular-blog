using Blog.Api.Bootstrap;

namespace Blog.Api.Extensions
{
    public static class StartupExtensions
    {
        public static WebApplicationBuilder UseStartup<TStartup>(this WebApplicationBuilder webApplication) where TStartup : INativeInjectorBootStrapper
        {
            var startup = Activator.CreateInstance(typeof(TStartup), webApplication.Configuration) as INativeInjectorBootStrapper;

            if (startup is null) throw new ArgumentException("Startup class invalid!");

            startup.ConfigureServices(webApplication.Services);

            var app = webApplication.Build();
            startup.Configure(app, app.Environment);

            app.Run();

            return webApplication;
        }
    }
}
