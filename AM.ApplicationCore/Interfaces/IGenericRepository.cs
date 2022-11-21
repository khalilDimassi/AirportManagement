using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity getEntityByID(params object[] keyvalues);

        void InsertEntity(TEntity entity);
        void DeleteEntity(TEntity entity);
        void UpdateEntity(TEntity entity);

        void DeleteEntity(Expression<Func<TEntity, bool>> predicate);
        void InsertEntity(Expression<Func<TEntity, bool>> predicate);
        void UpdateEntity(Expression<Func<TEntity, bool>> predicate);
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate);

        void save();
    }
}
