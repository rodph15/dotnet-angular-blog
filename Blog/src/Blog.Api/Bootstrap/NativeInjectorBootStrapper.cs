using Blog.Application.Extensions;
using Blog.Infrastructure.Extensions;
using Raven.Client.Documents;
using Raven.DependencyInjection;

namespace Blog.Api.Bootstrap
{
    public class NativeInjectorBootStrapper : INativeInjectorBootStrapper
    {
        public IConfiguration Configuration { get; }

        public NativeInjectorBootStrapper(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddRavenDbDocStore();
            services.AddRavenDbAsyncSession();
            services.ConfigureApplicationServices();
            services.ConfigureInfrastructureServices();
        }

        public void Configure(WebApplication app, IWebHostEnvironment webHostEnvironment)
        {
            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Services.GetRequiredService<IDocumentStore>().EnsureExists();
        }
    }
}
