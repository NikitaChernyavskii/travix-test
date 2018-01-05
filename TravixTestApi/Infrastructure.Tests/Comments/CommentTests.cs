using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using Infrastructure.Comments.Contract;
using Infrastructure.Comments.Models;
using Infrastructure.Comments.Services;
using Infrastructure.Comments.Validators;
using Infrastructure.Infrastructure.Contract;
using Infrastructure.Repository.Contract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Infrastructure.Tests.Comments
{
    [TestClass]
    public class CommentTests
    {
        private Mock<IRepository<Comment>> _mockCommentRepository;
        private Mock<IValidator<CommentModel>> _mockCommentValidator;

        [TestInitialize]
        public void Initialize()
        {
            _mockCommentRepository = new Mock<IRepository<Comment>>();
            _mockCommentValidator = new Mock<IValidator<CommentModel>>();
        }

        [TestMethod]
        public void GetComments_Successfully()
        {
            ICommentService commentService = CreateCommentService();
            List<Comment> commentEntities = CreateComments();
            _mockCommentRepository.Setup(r => r.Get()).Returns(Task.FromResult(commentEntities));

            List<CommentView> commentsResult = Task.Run(() => commentService.Get()).Result;

            Assert.AreEqual(commentEntities, commentsResult);
        }

        private List<Comment> CreateComments()
        {
            return new List<Comment>
            {
                new Comment
                {
                    Id = new Guid("9834d7b9-618d-435b-b86e-d9e861111738"),
                    PostId = new Guid("79b43335-ac35-4752-a3b7-a2233ad2ab28"),
                    Value = "Avery Watts – A Cut Above"
                },
                new Comment
                {
                    Id = new Guid("7aa4c351-ea53-41db-9323-73cf37d86ae0"),
                    PostId = new Guid("79b43335-ac35-4752-a3b7-a2233ad2ab28"),
                    Value = "Asenblut – Berserkerzorn"
                }
            };
        }

        private ICommentService CreateCommentService()
        {
            return new CommentService
            {
                CommentRepository = _mockCommentRepository.Object,
                CommentValidator = _mockCommentValidator.Object
            };
        }
    }
}
