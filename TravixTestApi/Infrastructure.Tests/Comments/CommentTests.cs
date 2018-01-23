using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Comments.Contract;
using Core.Comments.Models;
using Core.Comments.Services;
using Core.Comments.Validators;
using Core.Infrastructure;
using Core.Infrastructure.Contract;
using DAL.Entities;
using DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Core.Tests.Comments
{
    [TestClass]
    public class CommentTests
    {
        private Mock<IRepository<Comment>> _mockCommentRepository;
        private Mock<IValidator<CommentModel>> _mockCommentValidator;

        [TestInitialize]
        public void Initialize()
        {
            InitializeMappingService.InitializaAutoMapper();
            _mockCommentRepository = new Mock<IRepository<Comment>>();
            _mockCommentValidator = new Mock<IValidator<CommentModel>>();
        }

        [TestMethod]
        public async Task GetComments_Successfully()
        {
            ICommentService commentService = CreateCommentService();
            List<Comment> commentEntities = CreateComments();
            _mockCommentRepository.Setup(r => r.Get()).Returns(Task.FromResult(commentEntities));

            List<CommentView> commentsResult = await commentService.Get();

            Assert.AreEqual(commentEntities.Count, commentsResult.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Comment cannot be empty")]
        public void CommentValidator_ThrowsEmptyOrNullValue()
        {
            CommentModel model = new CommentModel
            {
                PostId = new Guid("9834d7b9-618d-435b-b86e-d9e861111738"),
                Value = String.Empty
            };
            CommentValidator validator = new CommentValidator();

            validator.Validate(model);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException), "Comment cannot be less then 10 and cannot exceed 1000")]
        public void CommentValidator_ThrowsInvalidValueLength()
        {
            CommentModel model = new CommentModel
            {
                PostId = new Guid("9834d7b9-618d-435b-b86e-d9e861111738"),
                Value = "too small"
            };
            CommentValidator validator = new CommentValidator();

            validator.Validate(model);
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
