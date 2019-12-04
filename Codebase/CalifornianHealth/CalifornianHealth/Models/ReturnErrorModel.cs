using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Models
{
    public class ReturnErrorModel
    {
        public string message { get; set; }
        public Dictionary<string, string[]> modelState { get; set; }
    }
}