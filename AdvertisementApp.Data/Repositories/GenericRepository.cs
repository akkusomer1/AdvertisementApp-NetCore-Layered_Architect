using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Enums;
using Udemy.AdvertisementApp.Core.Repositories;
using Udemy.AdvertisementApp.Data.Context;

namespace Udemy.AdvertisementApp.Data.Repositories
{
    public class GenericRepository<TEntity>:IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AdvertisementContext _context;

        public GenericRepository(AdvertisementContext context)
        {
            _context = context;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().AsNoTracking().ToListAsync();
        }


        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.DESC
                ? await _context.Set<TEntity>().OrderByDescending(selector).AsNoTracking().ToListAsync()
                : await _context.Set<TEntity>().OrderBy(selector).AsNoTracking().ToListAsync();
        }

        public async Task<List<TEntity>> GetAllAsync<TKey>(Expression<Func<TEntity, bool>> filter,
            Expression<Func<TEntity, TKey>> selector, OrderByType orderByType = OrderByType.DESC)
        {
            return orderByType == OrderByType.DESC
               ? await _context.Set<TEntity>().Where(filter).OrderByDescending(selector).AsNoTracking().ToListAsync()
               : await _context.Set<TEntity>().Where(filter).OrderBy(selector).AsNoTracking().ToListAsync();
        }

        public async Task<TEntity?> FindAsync(object id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity?> GetByFilterAsync(Expression<Func<TEntity, bool>> filter, bool asNoTracking=false)
        {
            return !asNoTracking
                ? await _context.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(filter)
                : await _context.Set<TEntity>().SingleOrDefaultAsync(filter);
        }

        
        public IQueryable<TEntity> GetQuery()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
       
        public async Task CreateAsync(TEntity entity)
        {
          await  _context.Set<TEntity>().AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

    }

}

