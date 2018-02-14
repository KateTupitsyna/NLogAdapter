using System;
using NLog;

namespace ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Info("My message");
                throw new Exception("Test");
            }
            catch (Exception exception)
            {
                var logger = LogManager.GetCurrentClassLogger();
                logger.Error(exception, "My error");
            }

            Console.ReadKey();
        }
    }
}
