using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using Infrastructure.Infrastructure;

namespace Infrastructure.Comments.Services
{
    public class CommentRepository : IRepository<Comment>
    {
        // should be changed to db context in real case.
        private static List<Comment> _mockedComments;

        public CommentRepository()
        {
            _mockedComments = CreateMockedComments();
        }

        public async Task<List<Comment>> Get()
        {
            return await GetMockedComments();
        }

        public async Task<Comment> GetById(Guid id)
        {
            return (await GetMockedComments()).FirstOrDefault(c => c.Id == id);
        }

        public async Task Create(Comment entity)
        {
            entity.Id = Guid.NewGuid();
            await Task.Run(() => _mockedComments.Add(entity));
        }

        public async Task Update(Guid id, Comment entity)
        {
            Comment comment = await GetById(id);
            if (comment == null)
            {
                return;
            }

            // change State of entity to EntityState.Modified in real case.
            comment.Value = comment.Value;
        }

        private Task<List<Comment>> GetMockedComments()
        {
            return Task.FromResult(_mockedComments);
        }

        private List<Comment> CreateMockedComments()
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
    }
}
