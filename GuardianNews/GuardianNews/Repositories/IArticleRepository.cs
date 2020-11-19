using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.Repositories
{
    public interface IArticleRepository<Article>
    {
        void AddAsync(Article article);

        void AddRangeAsync(Article[] articles);

        Task<Article[]> GetAllAsync();

    }
}
