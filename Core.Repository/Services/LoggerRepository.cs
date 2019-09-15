using Core.EntityLayer.Cache;
using Core.EntityLayer.Context;
using Core.EntityLayer.Models;
using Core.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Repository.Services
{
    public class LoggerRepository : ILoggerRepository
    {
        private AppDbContext _appDbContext;
        public LoggerRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }
        public void Error(string controller, string method, Exception ex, string message, string username, Dictionary<string, string> parameters = null)
        {
            string parameter = string.Empty;
            if (parameters != null)
                foreach (var item in parameters)
                {
                    parameter += $"{item.Key}:{item.Value} ";
                }
            var model = new Log
            {
                Exception = ex.ToString(),
                Message = message,
                LogType = LogType.Error,
                Controller = controller,
                Method = method,
                Username = username,
                CreatedOn = DateTime.Now,
                Parameters = parameter
            };
            _appDbContext.Logs.Add(model);
            _appDbContext.SaveChangesAsync();

        }

        public void Info(string controller, string method, string message, string username)
        {
            var model = new Log
            {
                Message = message,
                Method = method,
                Controller = controller,
                Username = username,
                CreatedOn = DateTime.Now,
                LogType = LogType.Info
            };
            _appDbContext.Logs.Add(model);
            _appDbContext.SaveChangesAsync();
        }
    }
}
