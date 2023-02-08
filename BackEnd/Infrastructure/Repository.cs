using CrossCutting.Exception;
using Domain;
using Infrastructure.DataAcces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Members

        private readonly DbSet<TEntity> dbSet;

        #endregion

        #region Constructors

        public Repository(AplicationDbContext dbContext)
        {
            Argument.ThrowIfNull(() => dbContext);
            this.dbSet = dbContext.Set<TEntity>();
        }

        #endregion

        #region Methods

        public void Add(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.AddRange(entities);
        }

        public IQueryable<TEntity> All()
        {
            return this.dbSet.AsQueryable();
        }

        public IQueryable<TEntity> AllAsNoTracking()
        {
            return this.dbSet.AsNoTracking();
        }

        public void Remove(TEntity entity)
        {
            this.dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.dbSet.RemoveRange(entities);
        }

        #endregion
    }
}
