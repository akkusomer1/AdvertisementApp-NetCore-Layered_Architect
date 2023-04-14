using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Enums;

namespace Udemy.AdvertisementApp.Core.Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : BaseEntity,new()
    {
        Task<List<TEntity>> GetAllAsync();
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TKey>> selector, OrderByType orderByType = OrderByType.DESC);
        Task<TEntity> FindAsync(object id);
        Task<TEntity> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking = false);
        IQueryable<TEntity> GetQuery();
        void Remove(TEntity entity);
        Task CreateAsync(TEntity entity);
        void Update(TEntity entity);
    }
}
