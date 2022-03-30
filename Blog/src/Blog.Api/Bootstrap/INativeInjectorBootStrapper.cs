namespace Blog.Api.Bootstrap
{
    public interface INativeInjectorBootStrapper
    {
        IConfiguration Configuration { get; }
        void ConfigureServices(IServiceCollection services);
        void Configure(WebApplication app, IWebHostEnvironment webHostEnvironment);
    }
}
