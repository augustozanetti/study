using Hyper.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Hyper.Domain.Interfaces.Repositories
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        Task<TEntity> Add(TEntity obj);

        TEntity GetById(int id);

        IEnumerable<TEntity> GetAll();

        TEntity Update(TEntity obj);

        void Remove(int id);

        IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> predicate);

        int SaveChanges();
    }
}