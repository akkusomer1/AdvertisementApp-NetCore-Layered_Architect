using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Repositories;
using Udemy.AdvertisementApp.Core.UnitOfWork;
using Udemy.AdvertisementApp.Data.Context;
using Udemy.AdvertisementApp.Data.Repositories;

namespace Udemy.AdvertisementApp.Data.UnitofWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AdvertisementContext _context;

        public UnitOfWork(AdvertisementContext context)
        {
            _context = context;
        }

       
        public IGenericRepository<T> GetRepository<T>() where T : BaseEntity,new()
        {
            return new GenericRepository<T>(_context);
        }

        public void Commit()
        {
           _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
          await _context.SaveChangesAsync();
        }

      
    }
}
