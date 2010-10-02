using System;

namespace NHibernate3Sample.Autofac.Logging
{
    public class Log4NetWrapper : ILog
    {
        private readonly log4net.ILog _logger;

        public static ILog GetLogger(Type type)
        {
            return new Log4NetWrapper(type);
        }

        public Log4NetWrapper(Type type)
        {
            _logger = log4net.LogManager.GetLogger(type);
        }

        public void Info(string message)
        {
            _logger.Info(message);
        }

        public void Warning(string message)
        {
            _logger.Warn(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }

        public void Exception(Exception exception)
        {
        }
    }
}