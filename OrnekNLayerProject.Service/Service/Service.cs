using OrnekNLayerProject.Core.Repositories;
using OrnekNLayerProject.Core.Services;
using OrnekNLayerProject.Core.UnitOfWork;

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrnekNLayerProject.Service.Service
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IRepositories<TEntity> _repository;

        public Service(IUnitOfWork unitOfWork,IRepositories<TEntity> repositories)
        {
            _unitOfWork = unitOfWork;
            _repository = repositories;
        }
         
        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;

        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _repository.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async  Task<TEntity> GetByIdAysnc(int id)
        {
            return await _repository.GetByIdAysnc(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _unitOfWork.Commit();
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _repository.RemoveRange(entities);
            _unitOfWork.Commit();

        }

        public async  Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var t = await _repository.SingleOrDefaultAsync(predicate);
            return t;
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updateproduct=_repository.Update(entity);
            _unitOfWork.Commit();
            return updateproduct;
        }

        public async  Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.Where(predicate);
        }
    }
}
