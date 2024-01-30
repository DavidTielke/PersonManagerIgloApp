using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossCutting.Configuration
{
    public interface IConfigurator
    {
        TItem Get<TItem>(string key);
        void Set(string key, object value);
    }
}
