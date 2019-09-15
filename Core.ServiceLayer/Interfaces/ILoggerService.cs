using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ServiceLayer.Interfaces
{
    public interface ILoggerService
    {
        void Error(string controller,string method,Exception ex, string message,string username, Dictionary<string,string> parameters=null);
        void Info(string controller,string method, string message,string username);
    }
}
