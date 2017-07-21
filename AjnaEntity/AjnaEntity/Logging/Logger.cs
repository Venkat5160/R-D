using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Diagnostics;
using System.Text;

namespace AjnaEntity.Logging
{
    public class Logger:ILogger
    {

        public void information(string message)
        {
            Trace.TraceInformation(message);
            //throw new NotImplementedException();
        }

        public void information(string fmt, params object[] vars)
        {
            //throw new NotImplementedException();
            Trace.TraceInformation(fmt, vars);
        }

        public void information(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceInformation(FormatExceptionMessage(exception, fmt, vars));
            //throw new NotImplementedException();
        }

        private string FormatExceptionMessage(Exception exception, string fmt, object[] vars)
        {
            var sb = new StringBuilder();
            sb.Append(string.Format(fmt, vars));
            sb.Append(" Exception: ");
            sb.Append(exception.ToString());
            return sb.ToString();
        }

        public void Warning(string message)
        {
            Trace.TraceWarning(message);
            //throw new NotImplementedException();
        }

        public void Warning(string fmt, params object[] vars)
        {
            Trace.TraceWarning(fmt, vars);
            //throw new NotImplementedException();
        }

        public void Warning(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceWarning(FormatExceptionMessage(exception, fmt, vars));
            //throw new NotImplementedException();
        }

        public void Error(string message)
        {
            Trace.TraceError(message);
            //throw new NotImplementedException();
        }

        public void Error(string message, params object[] vars)
        {
            Trace.TraceError(message, vars);
            //throw new NotImplementedException();
        }

        public void Error(Exception exception, string fmt, params object[] vars)
        {
            Trace.TraceError(FormatExceptionMessage(exception, fmt, vars));
           // throw new NotImplementedException();
        }

        public void TraceApi(string componentName, string method, TimeSpan timeSpan)
        {
            TraceApi(componentName, method, timeSpan,"");
            //throw new NotImplementedException();
        }

        public void TraceApi(string componentName, string method, TimeSpan timeSpan, string properties)
        {
            string message = string.Concat("Component:", componentName, "Method:", method, "TimeSpan:", timeSpan, "Properties:", properties);
            //throw new NotImplementedException();
        }

        public void TraceApi(string componentName, string method, TimeSpan timeSpan, string fmt, params object[] vars)
        {
            TraceApi(componentName, method, timeSpan, string.Format(fmt, vars));
            //throw new NotImplementedException();
        }
    }
}