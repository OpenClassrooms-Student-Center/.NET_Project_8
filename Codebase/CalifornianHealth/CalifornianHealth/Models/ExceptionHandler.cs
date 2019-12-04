using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class ExceptionHandler
    {
        public string message { get; set; }
        public string exceptionMessage { get; set; }
        public string exceptionType { get; set; }
        public string stackTrace { get; set; }
    }
}