using System.Web;
using System.Web.Mvc;

namespace InvoiceManager
{
    public class FilterConfig
    {

        private static readonly NLog.Logger Logger = 
            NLog.LogManager.GetCurrentClassLogger();

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new CustomExceptionFilter());
        }

        public class CustomExceptionFilter : IExceptionFilter
        {
            public void OnException(ExceptionContext filterContext)
            {
                var exception = filterContext.Exception;
                Logger.Error(exception);
            }
        }
    }
}
