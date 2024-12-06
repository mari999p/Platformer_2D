using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using Debug = UnityEngine.Debug;

namespace Platformer.Game.Utils.Log
{
    public static class Logger
    {
        #region Public methods

        public static void Error(this object obj, object message = null, Exception exception = null,
            [CallerMemberName] string memberName = "")
        {
            Debug.LogError(FormatMessage(obj.GetType(), memberName, message, exception));
        }

        [Conditional("UNITY_EDITOR")] [Conditional("DEBUG")]
        public static void Log(this object obj, object message = null, [CallerMemberName] string memberName = "")
        {
            Debug.Log(FormatMessage(obj.GetType(), memberName, message));
        }

        [Conditional("UNITY_EDITOR")] [Conditional("DEBUG")]
        public static void Warning(this object obj, object message = null, [CallerMemberName] string memberName = "")
        {
            Debug.LogWarning(FormatMessage(obj.GetType(), memberName, message));
        }

        #endregion

        #region Private methods

        private static string FormatMessage(Type type, string memberName, object message, Exception exception = null)
        {
            string prefix = Application.isEditor
                ? $"[{Time.frameCount}]"
                : $"[{DateTime.Now:HH:mm:ss} : {Time.frameCount}]";

            string exceptionMessage = exception != null ? $"\\nException: {exception}" : string.Empty;
            string finalMessage = message != null ? message.ToString() : "null";

            return $"{prefix} [{type.Name} : {memberName}] {finalMessage}{exceptionMessage}";
        }

        #endregion
    }
}