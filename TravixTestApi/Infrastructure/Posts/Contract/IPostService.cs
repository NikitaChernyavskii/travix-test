using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Posts.Models;

namespace Core.Posts.Contract
{
    public interface IPostService
    {
        Task<List<PostView>> Get();
        Task<PostView> GetById(Guid id);
        Task Create(PostModel model);
        Task Update(Guid id, PostModel model);
    }
}
