using System;
using System.Runtime.CompilerServices;


namespace Helpers
{
    public interface ILogger
    {
        void LogTrace(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0);

        void LogDebug(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0);

        void LogInfo(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0);

        void LogWarn(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0);

        void LogError(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0);

        void LogFatal(object message, Exception ex = null, [CallerMemberName]string memberName = "", [CallerFilePath]string sourceFilePath = "", [CallerLineNumber]int sourceLineNumber = 0);

        bool IsTraceEnabled { get; }

        bool IsDebugEnabled { get; }

        bool IsInfoEnabled { get; }

        bool IsWarnEnabled { get; }

        bool IsErrorEnabled { get; }

        bool IsFatalEnabled { get; }
    }
}
