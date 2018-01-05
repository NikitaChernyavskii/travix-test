using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Infrastructure.Infrastructure;

namespace Infrastructure.Posts.Services
{
    public class PostRepository : IRepository<Post>
    {
        // should be changed to db context in real case.
        private static List<Post> _mockedPosts;

        public PostRepository()
        {
            _mockedPosts = CreateMockedPosts();
        }

        public async Task<List<Post>> Get()
        {
            return await GetMockedPosts();
        }

        public async Task<Post> GetById(Guid id)
        {
            return (await GetMockedPosts()).FirstOrDefault(c => c.Id == id);
        }

        public async Task Create(Post entity)
        {
            entity.Id = Guid.NewGuid();
            await Task.Run(() => _mockedPosts.Add(entity));
        }

        public async Task Update(Guid id, Post entity)
        {
            Post post = await GetById(id);
            if (post == null)
            {
                return;
            }

            // change State of entity to EntityState.Modified in real case.
            // Update some real fields here
        }

        private Task<List<Post>> GetMockedPosts()
        {
            return Task.FromResult(_mockedPosts);
        }

        private List<Post> CreateMockedPosts()
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
    }
}
