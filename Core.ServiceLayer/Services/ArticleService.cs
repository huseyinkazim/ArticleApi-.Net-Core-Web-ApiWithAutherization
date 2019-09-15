using Core.ServiceLayer.Core;
using Core.DtoLayer.Dto;
using Core.EntityLayer.Context;
using Core.EntityLayer.Models;
using Core.Repository.Interfaces;
using Core.ServiceLayer.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.ServiceLayer.Services
{
    public class ArticleService: IArticleService
    {
        private IArticleRepository _articleRepository;
        public ArticleService(IArticleRepository articleRepository)
        {
            this._articleRepository=articleRepository;
        }

        public int Add(ArticleDto article)
        {
            var model= Converter.MapTo<ArticleDto, Article>(article);
             return _articleRepository.Add(model);
        }

        public int Delete(ArticleDto article)
        {
            var model = Converter.MapTo<ArticleDto, Article>(article);

            return _articleRepository.Delete(model);
        }

        public IEnumerable<ArticleDto> GetArticles()
        {
            return Converter.MapToList<Article,ArticleDto>(_articleRepository.GetArticles());
        }
        public ArticleDto GetById(int Id)
        {
            var model = _articleRepository.GetById(Id);
            return model!=null? Converter.MapTo<Article, ArticleDto>(model):null;
        }

        public IEnumerable<ArticleDto> SearchInTitleArticles(string value)
        {
            return Converter.MapToList<Article, ArticleDto>(_articleRepository.SearchInTitleArticles(value));
        }
        public IEnumerable<ArticleDto> SearchInContentArticles(string value)
        {
            return Converter.MapToList<Article, ArticleDto>(_articleRepository.SearchInContentArticles(value));
        }
        public int Update(ArticleDto article)
        {
           
            var model = Converter.MapTo<ArticleDto, Article>(article);
           return _articleRepository.Update(model);
        }
    }
}
