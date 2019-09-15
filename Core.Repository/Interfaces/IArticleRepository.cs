using Core.EntityLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository.Interfaces
{
    public interface IArticleRepository
    {
        IEnumerable<Article> GetArticles();
        Article GetById(int Id);
        IEnumerable<Article> SearchInTitleArticles(string content);
        IEnumerable<Article> SearchInContentArticles(string content);
        int Add(Article article);
        int Update(Article article);
        int Delete(Article article);

    }
}
