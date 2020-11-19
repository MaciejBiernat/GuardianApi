using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.Repositories
{
    public interface IRepository<T> where T : class
    {
        void AddAsync(T entity);

        void AddRangeAsync(T[] entity);

        Task<T[]> GetAllAsync();

    }
}
