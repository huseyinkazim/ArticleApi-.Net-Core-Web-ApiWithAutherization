using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.EntityLayer.Context;
using Core.EntityLayer.Models;
using Core.ServiceLayer.Interfaces;
using Core.DtoLayer.Dto;
using Microsoft.AspNetCore.Authorization;
using Core.Business;

namespace Core.Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleService _articleService;
        private readonly LogManager _logManager;
        private string username => User.Claims.FirstOrDefault().Value.ToUpper();
        private const string controllername = "Articles";
        public ArticlesController(IArticleService articleService, ILoggerService loggerService)
        {
            this._articleService = articleService;
            this._logManager = new LogManager(loggerService);
        }

        // GET: api/Articles
        [HttpGet]
        public IActionResult GetArticles()
        {
            var methodname = "GetArticles";

            try
            {
                var model = _articleService.GetArticles();
                _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);
                if (model.Count() != 0)
                    return Ok(model);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }


        }

        // GET: api/Articles/5
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var methodname = "GetById";
            try
            {
                var model = _articleService.GetById(id);
                _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);
                if (model == null)
                {
                    return NotFound();
                }
                return Ok(model);
            }
            catch (Exception ex)
            {
                var parameters = new Dictionary<string, string>
                {
                    {"id",id.ToString()}
                };
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username, parameters);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }
        }

        // [HttpGet("{searching_key}")]
        [HttpGet("{title}")]
        public IActionResult SearchInTitle(string title)
        {
            var methodname = "SearchTitle";
            try
            {

                var model = _articleService.SearchInTitleArticles(title);
                _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);
                if (model.Count() != 0)
                    return Ok(model);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                var parameters = new Dictionary<string, string>
                {
                    {"title",title}
                };
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }
        }
        [HttpGet("{content}")]
        public IActionResult SearchInContent(string content)
        {
            var methodname = "SearchInContent";
            try
            {

                var model = _articleService.SearchInContentArticles(content);
                _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);
                if (model.Count() != 0)
                    return Ok(model);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                var parameters = new Dictionary<string, string>
                {
                    {"content",content},
                };
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }
        }
        [HttpPost]
        public IActionResult Add([FromBody]ArticleDto article)
        {
            var methodname = "SearchInContent";
            try
            {
                var id = _articleService.Add(article);
                _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);

                if (id != 0)
                {
                    return Ok(new { Id = id });
                }
                else
                {
                    throw new Exception("Ekleme işleminde kaydetme sırasında hata");
                }
            }
            catch (Exception ex)
            {
                var parameters = article.GetParameters();
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username, parameters);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }
        }
        [HttpPost]
        public IActionResult Update([FromBody]ArticleDto article)
        {
            var methodname = "Update";
            try
            {
                if (article.Id == 0)
                    return BadRequest("Id alanı zorunludur.");
                var isUpdated = _articleService.Update(article);


                if (isUpdated > 0)
                {
                    _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);
                    return Ok($"Id:{article.Id} güncelleştirme başarılı şekilde gerçekleştirildi");
                }
                else
                {
                    throw new Exception("Güncelleştirme işleminde kaydetme sırasında hata");
                }
            }
            catch (Exception ex)
            {
                var parameters = article.GetParameters();
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username, parameters);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }

        }
        [HttpPost("{id}")]
        public IActionResult Delete(int id)
        {
            var methodname = "Update";
            try
            {

                var isDeleted = _articleService.Delete(new ArticleDto { Id = id });

                if (isDeleted > 0)
                {
                    _logManager.Info(controllername, methodname, "Method başarılı şekilde çalışmıştır", username);
                    return Ok($"Id:{id} silme işlemi başarılı şekilde gerçekleştirildi");
                }
                else
                {
                    throw new Exception("Silme işleminde kaydetme sırasında hata");
                }

            }
            catch (Exception ex)
            {
                var parameters = new ArticleDto { Id = id }.GetParameters();
                _logManager.Error(controllername, methodname, ex, "Beklenmedik bir hata", username, parameters);
                return BadRequest("Beklenmedik bir hata oluştu.");
            }
        }
        private Dictionary<string, string> GetParameters<T>(T model)
        {
            var typeofT = typeof(T);
            var result = new Dictionary<string, string>();
            foreach (var item in typeofT.GetProperties())
            {
                var value = typeofT.GetProperty(item.Name).GetValue(model);
                if (value != null)
                {
                    result.Add(item.Name, value.ToString());
                }
            }
            return result;
        }

    }
}
