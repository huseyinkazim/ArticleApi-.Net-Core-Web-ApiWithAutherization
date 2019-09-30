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
        //Attach dediğimizde _context.Entry(article) state i Unchanged oluyor _context.Entry(article).Property(i => i.Title).IsModified = true; bu şekilde sadece property e değişkenlik atıyoruz
        //_context.Entry(article).State EnityState.Modified dersek tüm modele değişiklik atıyoruz aynı şekilde
        //Attach edilen article.Content = "Test amaçlı içerik mesajı"; dediğimizde modelde değişiklik gördüğü için tüm modelin state i Modified edilmiş oluyor
        public int Update(Article article)
        {
            //var s = new Article();
       
            // s = new Article
            //{
            //    Id = 1,
            //    Content = "Bu bir test makalesidir.Digiturk için yapılmıştır.",
            //    ModifiedOn = DateTime.Now,
            //    CreatedOn=DateTime.Now.AddDays(-15),
            //    //Title="Bla bla",//Bu alan boş bırakılınca null basıyor 
            //    IsActive=true                
            //};
            //_context.Articles.Update(s);//Aynısı  _context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            //_context.SaveChanges();

            if (_context.Articles.Any(i => i.Id == article.Id))
            {
                article.ModifiedOn = DateTime.Now;
                //_context.Entry(article).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                _context.Attach(article);
                _context.Entry(article).Property(i => i.Title).IsModified = true;
                _context.Entry(article).Property(i => i.Content).IsModified = true;
                _context.Entry(article).Property(i => i.ModifiedOn).IsModified = true;
                //article.Content = "Test amaçlı içerik mesajı";

                return _context.SaveChanges();
            }
            return 0;
        }
    }
}
