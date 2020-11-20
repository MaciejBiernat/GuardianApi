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
    public class ArticleRepository : IArticleRepository
    {
        private readonly GuardianContext _context;
        private DbSet<Article> table;
        public ArticleRepository(GuardianContext context)
        {
            _context = context;
            table = _context.Set<Article>();
        }

        public async void AddAsync(Article article)
        {
            await _context.AddAsync(article);
            _context.SaveChanges();
        }

        public async void AddRangeAsync(List<Article> articles)
        {
            await _context.AddRangeAsync(articles);
            _context.SaveChanges();
        }

        public async Task<List<Article>> GetAllAsync()
        {
            var result = await table.ToListAsync();
            return result;
        }

    }
}
