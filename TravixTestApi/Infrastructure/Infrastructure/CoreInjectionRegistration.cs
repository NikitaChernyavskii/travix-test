using Core.Comments.Contract;
using Core.Comments.Models;
using Core.Comments.Services;
using Core.Comments.Validators;
using Core.Infrastructure.Contract;
using Core.Posts.Contract;
using Core.Posts.Services;
using DAL.Entities;
using DAL.Repository;
using Ninject;

namespace Core.Infrastructure
{
    public static class CoreInjectionRegistration
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IRepository<Comment>>().To<CommentRepository>();
            kernel.Bind<IValidator<CommentModel>>().To<CommentValidator>();

            kernel.Bind<IPostService>().To<PostService>();
            kernel.Bind<IRepository<Post>>().To<PostRepository>();
        }
    }
}
