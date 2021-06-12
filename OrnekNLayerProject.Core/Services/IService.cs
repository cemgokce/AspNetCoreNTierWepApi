using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Core.Services
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAysnc(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        //category.SingleOrDefaultAsync(x=>x.name="Kalem")
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);

        TEntity Update(TEntity entity);
    }
}
