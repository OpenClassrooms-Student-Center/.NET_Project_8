using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalifornianHealth.Code
{
    public interface ISerialization
    {
        string Serialize<T>(object o);
        T Deserialize<T>(Stream stream);
    }
}
