using GuardianNews.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.Repositories
{
    public interface IArticleRepository
    {
        void AddAsync(Article article);

        void AddRangeAsync(List<Article> articles);

        Task<List<Article>> GetAllAsync();

    }
}
