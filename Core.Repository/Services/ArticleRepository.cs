using Core.EntityLayer.Context;
using Core.EntityLayer.Models;
using Core.Repository.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Repository.Services
{
    public class ArticleRepository : IArticleRepository
    {
        private AppDbContext _context;
        public ArticleRepository(AppDbContext appDbContext)
        {
            this._context = appDbContext;
        }

        public int Add(Article article)
        {
            article.IsActive = true;
            article.ModifiedOn = DateTime.Now;
            article.CreatedOn = DateTime.Now;
            _context.Articles.Add(article);

            _context.SaveChanges();
            return article.Id;
        }

        public int Delete(Article article)
        {
            article.IsActive = false;
            article.ModifiedOn = DateTime.Now;
            _context.Attach(article);
            _context.Entry(article).Property(i => i.IsActive).IsModified = true;
            _context.Entry(article).Property(i => i.ModifiedOn).IsModified = true;
            return _context.SaveChanges();
        }

        public IEnumerable<Article> GetArticles()
        {
            return _context.Articles.Where(i => i.IsActive == true).ToList();
        }
        public Article GetById(int Id)
        {
            var model = _context.Articles.Find(Id);
            if (model == null)
                return null;
            return model?.IsActive == true ? model : null;
        }
        public IEnumerable<Article> SearchInTitleArticles(string content)
        {
            return _context.Articles.Where(i => i.Title.Contains(content)).ToList();
        }
        public IEnumerable<Article> SearchInContentArticles(string content)
        {
            return _context.Articles.Where(i => i.Content.Contains(content)).ToList();
        }
        public int Update(Article article)
        {
            if (_context.Articles.Any(i => i.Id == article.Id))
            {
                article.ModifiedOn = DateTime.Now;
                _context.Attach(article);
                _context.Entry(article).Property(i => i.Title).IsModified = true;
                _context.Entry(article).Property(i => i.Content).IsModified = true;
                _context.Entry(article).Property(i => i.ModifiedOn).IsModified = true;

                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
