using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjnaEntity.Logging
{
    public interface ILogger
    {
        void information(string message);
        void information(string fmt, params object[] vars);
        void information(Exception exception, string fmt, params object[] vars);

        void Warning(string message);
        void Warning(string fmt,params object[] vars);
        void Warning(Exception exception, string fmt, params object[] vars);

        void Error(string message);
        void Error(string message,params object[] vars);
        void Error(Exception exception,string fmt,params object[] vars);

        void TraceApi(string componentName,string method,TimeSpan timeSpan);
        void TraceApi(string componentName, string method, TimeSpan timeSpan,string properties);
        void TraceApi(string componentName, string method, TimeSpan timeSpan,string fmt,params object[] vars);

    }
}
