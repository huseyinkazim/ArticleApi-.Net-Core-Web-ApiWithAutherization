using System;
using System.Collections.Generic;
using System.Text;

namespace Core.EntityLayer.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public string Controller { get; set; }
        public string LogType { get; set; }
        public string Exception { get; set; }
        public string Message { get; set; }
        public string Parameters { get; set; }
        public string Username { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
