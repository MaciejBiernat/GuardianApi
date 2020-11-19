using GuardianNews.Entities;
using GuardianNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardianNews.Services
{
    public static class Mapper
    {
        public static Article MapToEntity(ArticleModel model)
        {
            Article entity = new Article();
            entity.SectionName = model.SectionName;
            entity.WebPublicationDate = model.WebPublicationDate;
            entity.WebTitle = model.WebTitle;
            entity.WebUrl = model.WebUrl;

            return entity;
        }

        public static List<Article> MapToEntity(List<ArticleModel> models)
        {
            List<Article> entities = new List<Article>();
            foreach (var model in models)
            {
                Article entity = new Article();
                entity.SectionName = model.SectionName;
                entity.WebPublicationDate = model.WebPublicationDate;
                entity.WebTitle = model.WebTitle;
                entity.WebUrl = model.WebUrl;
                entities.Add(entity);
            }

            return entities;
        }

        public static ArticleModel MapToModel(Article entity)
        {
            ArticleModel model = new ArticleModel();
            model.SectionName = entity.SectionName;
            model.WebPublicationDate = entity.WebPublicationDate;
            model.WebTitle = entity.WebTitle;
            model.WebUrl =entity.WebUrl;

            return model;
        }

        public static List<ArticleModel> MapToModel(List<Article> entities)
        {
            List<ArticleModel> models = new List<ArticleModel>();
            foreach (var entity in entities)
            {
                ArticleModel model = new ArticleModel();
                model.SectionName = entity.SectionName;
                model.WebPublicationDate = entity.WebPublicationDate;
                model.WebTitle = entity.WebTitle;
                model.WebUrl = entity.WebUrl;
            }
            return models;
        }
    }
}
