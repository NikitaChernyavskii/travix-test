﻿using DAL.Entities;
using Infrastructure.Comments.Contract;
using Infrastructure.Comments.Models;
using Infrastructure.Comments.Services;
using Infrastructure.Comments.Validators;
using Infrastructure.Infrastructure.Contract;
using Ninject;

namespace Infrastructure.Infrastructure
{
    public static class InfrastructureInjectionRegistration
    {
        public static void Register(IKernel kernel)
        {
            kernel.Bind<IRepository<Comment>>().To<CommentRepository>();
            kernel.Bind<ICommentService>().To<CommentService>();
            kernel.Bind<IValidator<CommentModel>>().To<CommentValidator>();

        }
    }
}
