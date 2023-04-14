using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.AdvertisementApp.Core.Entities;
using Udemy.AdvertisementApp.Core.Repositories;

namespace Udemy.AdvertisementApp.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        IGenericRepository<T> GetRepository<T>() where T : BaseEntity,new();
        void Commit();
        Task CommitAsync();
    }
}
