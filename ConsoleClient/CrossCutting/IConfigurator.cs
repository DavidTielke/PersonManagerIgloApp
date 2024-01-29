using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleClient.CrossCutting
{
    public interface IConfigurator
    {
        TItem Get<TItem>(string key);
        void Set(string key, object value);
    }
}
