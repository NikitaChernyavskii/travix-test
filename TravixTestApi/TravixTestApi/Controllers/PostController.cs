using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Core.Posts.Contract;
using Core.Posts.Models;
using Ninject;

namespace TravixTestApi.Controllers
{
    [RoutePrefix("Posts")]
    public class PostController : ApiController
    {
        #region Injection

        [Inject]
        public IPostService PostService { get; set; }

        #endregion

        [HttpGet]
        [Route("")]
        public async Task<List<PostView>> Get()
        {
            return await PostService.Get();
        }

        [HttpPost]
        [Route("")]
        public async Task Create(PostModel model)
        {
            await PostService.Create(model);
        }

        [HttpPut]
        [Route("postId/{id}")]
        public async Task Create(Guid id, PostModel model)
        {
            await PostService.Update(id, model);
        }
    }
}