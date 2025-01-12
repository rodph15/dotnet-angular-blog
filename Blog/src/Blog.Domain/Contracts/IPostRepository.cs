﻿using Blog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Domain.Contracts
{
    public interface IPostRepository
    {
        Task<IReadOnlyCollection<Post>> GetPosts(int skip, int take);
        Task CreatePost(Post post);

        Task<IReadOnlyCollection<Post>> GetNewEntityPosts(string EntityId);

        Task<IReadOnlyCollection<Post>> GeEntityPosts(string EntityId);

        Task<bool> HasEntity(string EntityId);
    }
}
