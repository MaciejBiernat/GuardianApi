using GuardianNews.Data;
using GuardianNews.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.Repositories
{
    public class ArticleRepository : IRepository<Article>
    {
        private readonly GuardianContext _context;
        private DbSet<Article> table;
        public ArticleRepository(GuardianContext context)
        {
            _context = context;
            table = _context.Set<Article>();
        }

        public async void AddAsync(Article entity)
        {
            await _context.AddAsync(entity);
            _context.SaveChanges();
        }

        public async void AddRangeAsync(Article[] entities)
        {
            await _context.AddRangeAsync(entities);
            _context.SaveChanges();
        }

        public async Task<Article[]> GetAllAsync()
        {
            return await table.ToArrayAsync();
        }
    }
}
