using Core.DtoLayer.Dto;
using Core.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public class ArticleManager
    {
        private IArticleService _articleService;
        public ArticleManager(IArticleService articleService)
        {
            this._articleService = articleService;
        }

        public int Add(ArticleDto article)
        {
            return _articleService.Add(article);
        }

        public int Delete(ArticleDto article)
        {
            return _articleService.Delete(article);
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            return _articleService.GetArticles();
        }

        public ArticleDto GetById(int Id)
        {
            return _articleService.GetById(Id);
        }

        public IEnumerable<ArticleDto> SearchInContentArticles(string content)
        {
            return _articleService.SearchInContentArticles(content);
        }

        public IEnumerable<ArticleDto> SearchInTitleArticles(string content)
        {
            return _articleService.SearchInTitleArticles(content);
        }

        public int Update(ArticleDto article)
        {
            return _articleService.Update(article);

        }
    }
}
