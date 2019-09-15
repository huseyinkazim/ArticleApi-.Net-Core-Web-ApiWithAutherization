using Core.DtoLayer.Dto;
using Core.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ServiceLayer.Interfaces
{
    public interface IArticleService
    {
        IEnumerable<ArticleDto> GetArticles();
        ArticleDto GetById(int Id);
        IEnumerable<ArticleDto> SearchInTitleArticles(string content);
        IEnumerable<ArticleDto> SearchInContentArticles(string content);
        int Add(ArticleDto article);
        int Update(ArticleDto article);
        int Delete(ArticleDto article);

    }
}
