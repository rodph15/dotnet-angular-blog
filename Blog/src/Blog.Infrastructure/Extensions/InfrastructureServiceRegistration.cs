using Blog.Domain.Contracts;
using Blog.Domain.Entities;
using Blog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Raven.Client.Documents;
using Raven.Client.ServerWide;
using Raven.Client.ServerWide.Operations;

namespace Blog.Infrastructure.Extensions
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IPostRepository, PostRepository>();
            return services;
        }

        public static IDocumentStore EnsureExists(this IDocumentStore store)
        {
            using var dbSession = store.OpenSession();
            try
            {
                dbSession.Query<Post>().Take(0).ToList();
            }
            catch (Raven.Client.Exceptions.Database.DatabaseDoesNotExistException)
            {
                store.Maintenance.Server.Send(new CreateDatabaseOperation(new DatabaseRecord
                {
                    DatabaseName = store.Database
                }));
            }

            if (!dbSession.Query<CommentedEntity>().Any())
            {
                dbSession.Store(new CommentedEntity
                {
                    Id = Guid.NewGuid().ToString()
                });
                dbSession.SaveChanges();
            }

            return store;
        }
    }
}
