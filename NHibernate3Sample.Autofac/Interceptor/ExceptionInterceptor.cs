using System;
using System.Reflection;
using Castle.Core.Interceptor;

namespace NHibernate3Sample.Autofac.Interceptor
{
    using Logging;

    public class ExceptionInterceptor : IInterceptor
    {
        private ILog _logger;

        public ExceptionInterceptor()
            : this(Log4NetWrapper.GetLogger(MethodBase.GetCurrentMethod().DeclaringType))
        {
        }

        public ExceptionInterceptor(ILog logger)
        {
            _logger = logger;
        }

        public void Intercept(IInvocation invocation)
        {
            try
            {
                _logger.Info("Before call " + invocation.Method.Name + " method");
                invocation.Proceed();
                _logger.Info("After call " + invocation.Method.Name + " method");
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                throw;
            }
        }
    }
}