using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Hyper.Domain.Entities;
using Hyper.Domain.Interfaces.Repositories;
using Hyper.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Hyper.Infra.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected AppDataContext Db;
        protected DbSet<TEntity> DbSet;

        protected Repository(AppDataContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public async virtual Task<TEntity> Add(TEntity obj)
        {
            var objReturn = await DbSet.AddAsync(obj);
            
            return objReturn.Entity;
        }

        public virtual TEntity Update(TEntity obj)
        {
            var entry = Db.Entry(obj);
            DbSet.Attach(obj);
            entry.State = EntityState.Modified;
            
            return obj;
        }

        public IEnumerable<TEntity> GetByCondition(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Where(predicate);
        }

        public void Dispose()
        {
            Db.Dispose();
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public virtual void Remove(int id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public virtual int SaveChanges()
        {
            return Db.SaveChanges();
        }
    }
}