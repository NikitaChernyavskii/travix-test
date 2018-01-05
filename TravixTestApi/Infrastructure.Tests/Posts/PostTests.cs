using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;
using Infrastructure.Infrastructure;
using Infrastructure.Posts.Contract;
using Infrastructure.Posts.Models;
using Infrastructure.Posts.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Infrastructure.Tests.Posts
{
    [TestClass]
    public class PostTests
    {
        private Mock<IRepository<Post>> _mockPostRepository;

        [TestInitialize]
        public void Initialize()
        {
            InitializeMappingService.InitializaAutoMapper();
            _mockPostRepository = new Mock<IRepository<Post>>();
        }

        [TestMethod]
        public void GetPosts_Successfully()
        {
            IPostService postService = CreatePostService();
            List<Post> postEntities = CreatePosts();
            _mockPostRepository.Setup(r => r.Get()).Returns(Task.FromResult(postEntities));
            List<PostView> postsResult = Task.Run(() => postService.Get()).Result;

            Assert.AreEqual(postEntities.Count, postsResult.Count);
        }

        private List<Post> CreatePosts()
        {
            return new List<Post>
            {
                new Post
                {
                    Id = new Guid("79b43335-ac35-4752-a3b7-a2233ad2ab28"),
                    Comments = new List<Comment>
                    {
                        new Comment
                        {
                            Id = new Guid("9834d7b9-618d-435b-b86e-d9e861111738"),
                            PostId = new Guid("79b43335-ac35-4752-a3b7-a2233ad2ab28"),
                            Value = "Avery Watts – A Cut Above"
                        }
                    } // get via Join in real case
                },
                new Post
                {
                    Id = new Guid("7aa4c351-ea53-41db-9323-73cf37d86a12"),
                    Comments = new List<Comment>() // get via Join in real case
                }
            };
        }

        private IPostService CreatePostService()
        {
            return new PostService
            {
                PostRepository = _mockPostRepository.Object
            };
        }
    }
}
