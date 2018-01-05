using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Entities;

namespace Infrastructure.Infrastructure
{
    // Repository should be 1 generic. But I created separated repositories for Comment and Post in order to be able to mock data.
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        Task<List<TEntity>> Get();
        Task<TEntity> GetById(Guid id);
        Task Create(TEntity entity);
        Task Update(Guid id, TEntity entity);
    }
}
