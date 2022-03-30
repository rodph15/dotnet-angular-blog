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

        public async Task<IReadOnlyCollection<Post>> GetPosts(int skip, int take) =>
          await _dbSession
                    .Query<Post>()
                    .Skip(0)
                    .Take(10)
                    .ToListAsync();
    }
}
