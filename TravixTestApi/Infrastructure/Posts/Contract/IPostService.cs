using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Infrastructure.Posts.Models;

namespace Infrastructure.Posts.Contract
{
    public interface IPostService
    {
        Task<List<PostView>> Get();
        Task<PostView> GetById(Guid id);
        Task Create(PostModel model);
        Task Update(Guid id, PostModel model);
    }
}
