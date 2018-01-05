using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Infrastructure.Comments.Contract;
using Infrastructure.Comments.Mapping;
using Infrastructure.Comments.Models;
using Infrastructure.Infrastructure.Contract;
using Infrastructure.Repository.Contract;
using Ninject;

namespace Infrastructure.Comments.Services
{
    public class CommentService : ICommentService
    {
        #region Injection

        [Inject]
        public IRepository<Comment> CommentRepository { get; set; }

        [Inject]
        public IValidator<CommentModel> CommentValidator { get; set; }

        #endregion

        public async Task<List<CommentView>> Get()
        {
            List<CommentView> comments = (await CommentRepository.Get()).Select(e => e.ToView()).ToList();

            return comments;
        }

        public async Task<CommentView> GetById(Guid id)
        {
            CommentView comment = (await CommentRepository.GetById(id))?.ToView();

            return comment;
        }

        public async Task Create(CommentModel model)
        {
            ValidateModel(model);
            await CommentRepository.Create(model.ToEntity());
        }

        public async Task Update(Guid id, CommentModel model)
        {
            ValidateModel(model);
            await CommentRepository.Update(id, model.ToEntity());
        }

        private void ValidateModel(CommentModel model)
        {
            CommentValidator.Validate(model);
        }
    }
}
