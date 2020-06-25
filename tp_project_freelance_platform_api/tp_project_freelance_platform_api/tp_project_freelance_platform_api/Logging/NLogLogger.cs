using NLog;
using System;
using System.IO;
using System.Runtime.CompilerServices;


namespace Helpers
{
    public class NLogLogger : ILogger
    {
        private readonly Logger _logger;

        public NLogLogger()
        {
            _logger = LogManager.GetCurrentClassLogger();
        }

        public NLogLogger(Type type)
        {
            _logger = LogManager.GetLogger(type.FullName);
        }

        public bool IsDebugEnabled
        {
            get
            {
                return _logger.IsDebugEnabled;
            }
        }

        public bool IsErrorEnabled
        {
            get
            {
                return _logger.IsErrorEnabled;
            }
        }

        public bool IsFatalEnabled
        {
            get
            {
                return _logger.IsFatalEnabled;
            }
        }

        public bool IsInfoEnabled
        {
            get
            {
                return _logger.IsInfoEnabled;
            }
        }

        public bool IsTraceEnabled
        {
            get
            {
                return _logger.IsTraceEnabled;
            }
        }

        public bool IsWarnEnabled
        {
            get
            {
                return _logger.IsWarnEnabled;
            }
        }

        public void LogDebug(object message, Exception ex = null, [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            var msg = ComposeMessage(message, memberName, sourceFilePath, sourceLineNumber);
            _logger.Debug(ex, msg);
        }

        public void LogError(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0)
        {
            var msg = ComposeMessage(message, memberName, sourceFilePath, sourceLineNumber);
            _logger.Error(ex, msg);
        }

        public void LogFatal(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0)
        {
            var msg = ComposeMessage(message, memberName, sourceFilePath, sourceLineNumber);
            _logger.Fatal(ex, msg);
        }

        public void LogInfo(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0)
        {
            var msg = ComposeMessage(message, memberName, sourceFilePath, sourceLineNumber);
            _logger.Info(ex, msg);
        }

        public void LogTrace(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0)
        {
            var msg = ComposeMessage(message, memberName, sourceFilePath, sourceLineNumber);
            _logger.Trace(ex, msg);
        }

        public void LogWarn(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var msg = ComposeMessage(message, memberName, sourceFilePath, sourceLineNumber);
            _logger.Warn(ex, msg);
        }

        protected virtual string ComposeMessage(object message, string memberName, string sourceFilePath, int sourceLineNumber)
        {
            string logMessage = message + "";
            if (!string.IsNullOrEmpty(sourceFilePath))
                logMessage = $"{logMessage} | {Path.GetFileName(sourceFilePath)}";
            if (!string.IsNullOrEmpty(memberName))
                logMessage = $"{logMessage} | {memberName}";
            if (sourceLineNumber != 0)
                logMessage = $"{logMessage} | {sourceLineNumber}";
            return logMessage;
        }
    }
}
