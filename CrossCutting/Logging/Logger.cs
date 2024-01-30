using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrossCutting.Contract.Logging;

namespace CrossCutting.Logging
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
