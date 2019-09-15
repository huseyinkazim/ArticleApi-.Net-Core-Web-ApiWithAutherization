using Core.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Business
{
    public class LogManager
    {
        private ILoggerService _loggerservice;
        public LogManager(ILoggerService loggerService)
        {
            this._loggerservice = loggerService;
        }

        public void Error(string controller, string method, Exception ex, string message, string username,Dictionary<string, string> parameters=null, bool sendmail = false)
        {
            _loggerservice.Error(controller,method, ex, message, username, parameters);
            if (sendmail)
                SendMail();
        }
        public void Info(string controller, string method, string message, string username,bool sendmail = false)
        {
            _loggerservice.Info(controller,method, message, username);
            if (sendmail)
                SendMail();
        }
        public void SendMail()
        {

        }

    }
}
