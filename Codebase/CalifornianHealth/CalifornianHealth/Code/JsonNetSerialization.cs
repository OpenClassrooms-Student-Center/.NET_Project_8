using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CalifornianHealth.Code
{
    public class JsonNetSerialization : ISerialization
    {
        public string Serialize<T>(object o)
        {
            return JsonConvert.SerializeObject((T)o);
        }

        public T Deserialize<T>(System.IO.Stream stream)
        {
            var json = new StreamReader(stream).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}