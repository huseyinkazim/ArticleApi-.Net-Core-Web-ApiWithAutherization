using Core.Repository.Interfaces;
using Core.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ServiceLayer.Services
{
    public class LoggerService : ILoggerService
    {
        public ILoggerRepository _loggerRepository;
        public LoggerService(ILoggerRepository loggerRepository)
        {
            this._loggerRepository = loggerRepository;
        }
        public void Error(string controller,string method, Exception ex, string message, string username, Dictionary<string, string> parameters = null)
        {
            _loggerRepository.Error(controller,method, ex, message, username, parameters);
        }

        public void Info(string controller,string method, string message,string username)
        {
            _loggerRepository.Info(controller,method, message, username);
        }
    }
}
