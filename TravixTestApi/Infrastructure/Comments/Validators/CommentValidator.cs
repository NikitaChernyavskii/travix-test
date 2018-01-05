using System;
using Infrastructure.Comments.Models;
using Infrastructure.Infrastructure;
using Infrastructure.Infrastructure.Contract;

namespace Infrastructure.Comments.Validators
{
    public class CommentValidator : IValidator<CommentModel>
    {
        public void Validate(CommentModel context)
        {
            if (String.IsNullOrEmpty(context.Value.Trim()))
            {
                throw new ValidationException("Comment cannot be empty");
            }

            if (context.Value.Length < 10 || context.Value.Length > 1000)
            {
                throw new ValidationException("Comment cannot be less then 10 and cannot exceed 1000");
            }
        }
    }
}
