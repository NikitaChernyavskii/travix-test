using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Comments.Models;

namespace Core.Comments.Contract
{
    public interface ICommentService
    {
        Task<List<CommentView>> Get();
        Task<CommentView> GetById(Guid id);
        Task Create(CommentModel model);
        Task Update(Guid id, CommentModel model);
    }
}
