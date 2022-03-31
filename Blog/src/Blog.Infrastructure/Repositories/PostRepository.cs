using Blog.Domain.Contracts;
using Blog.Domain.Entities;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly IAsyncDocumentSession _dbSession;

        public PostRepository(IAsyncDocumentSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task CreatePost(Post post)
        {
            await _dbSession.StoreAsync(post);
            await _dbSession.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<Post>> GeEntityPosts(string EntityId) =>
            await _dbSession
                    .Query<Post>()
                    .Where(x => x.CommentedEntity.Id.Equals(EntityId))
                    .ToListAsync();

        public async Task<IReadOnlyCollection<Post>> GetNewEntityPosts(string EntityId) =>
            await _dbSession
                    .Query<Post>()
                    .Where(x => x.CommentedEntity.Id.Equals(EntityId))
                    .OrderByDescending(x => x.CreatedAt)
                    .Take(5)
                    .ToListAsync();

        public async Task<IReadOnlyCollection<Post>> GetPosts(int skip, int take) =>
            await _dbSession
                    .Query<Post>()
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();

        public async Task<bool> HasEntity(string EntityId) =>
            await _dbSession
                    .Query<CommentedEntity>()
                    .AnyAsync(x => x.Id.Equals(EntityId));
    }
}
