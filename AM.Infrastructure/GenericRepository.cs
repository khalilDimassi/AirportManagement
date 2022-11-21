using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AM.Infrastructure
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        DbContext context_;
        DbSet<TEntity> dbset_;

        public GenericRepository(DbContext context)
        {
            context_ = context;
            dbset_ = context.Set<TEntity>();
        }

        public void DeleteEntity(TEntity entity)
        {
            dbset_.Remove(entity);
        }

        public void DeleteEntity(Expression<Func<TEntity, bool>> predicate)
        {
            dbset_.RemoveRange(dbset_.Where(predicate));
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbset_.AsEnumerable();
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset_.Where(predicate).FirstOrDefault();
        }
        
        public IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate)
        {
            return dbset_.Where(predicate).AsEnumerable();
        }

        public TEntity getEntityByID(params object[] keyvalues)
        {
            return dbset_.Find(keyvalues);
        }

        public void InsertEntity(TEntity entity)
        {
            dbset_.Add(entity);
        }

        public void InsertEntity(Expression<Func<TEntity, bool>> predicate)
        {
            dbset_.AddRange(dbset_.Where(predicate));
        }

        public void save()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(TEntity entity)
        {
            dbset_.Update(entity);
        }

        public void UpdateEntity(Expression<Func<TEntity, bool>> predicate)
        {
            dbset_.UpdateRange(dbset_.Where(predicate));
        }
    }
}
