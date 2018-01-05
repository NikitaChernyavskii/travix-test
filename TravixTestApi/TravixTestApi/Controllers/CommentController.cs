using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Infrastructure.Comments.Contract;
using Infrastructure.Comments.Models;
using Infrastructure.Infrastructure.Contract;
using Ninject;

namespace TravixTestApi.Controllers
{
    [RoutePrefix("Comments")]
    public class CommentController : ApiController
    {
        #region Injection

        [Inject]
        public ICommentService CommentService { get; set; }

        #endregion

        [HttpGet]
        [Route("")]
        public async Task<List<CommentView>> Get()
        {
            return await CommentService.Get();
        }

        [HttpPost]
        [Route("")]
        public async Task Create(CommentModel model)
        {
            await CommentService.Create(model);
        }
    }
}