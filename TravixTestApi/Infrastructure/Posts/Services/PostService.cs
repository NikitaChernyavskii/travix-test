using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Repository;
using Core.Posts.Contract;
using Core.Posts.Mapping;
using Core.Posts.Models;
using Ninject;

namespace Core.Posts.Services
{
    public class PostService : IPostService
    {
        #region Injection

        [Inject]
        public IRepository<Post> PostRepository { get; set; }

        #endregion

        public async Task<List<PostView>> Get()
        {
            List<PostView> posts = (await PostRepository.Get()).Select(e => e.ToView()).ToList();

            return posts;
        }

        public async Task<PostView> GetById(Guid id)
        {
            PostView post = (await PostRepository.GetById(id))?.ToView();

            return post;
        }

        public async Task Create(PostModel model)
        {
            await PostRepository.Create(model.ToEntity());
        }

        public async Task Update(Guid id, PostModel model)
        {
            await PostRepository.Update(id, model.ToEntity());
        }
    }
}
