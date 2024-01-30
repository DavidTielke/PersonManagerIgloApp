using DavidTielke.PMA.CrossCutting.Contract.Logging;

namespace DavidTielke.PMA.CrossCutting.Logging
{
    public class Logger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
