
namespace Framework.Logging
{
    public class Log
    {
        public static void Info(string content)
        {
            UnityEngine.Debug.Log(content);
        }
        
        public static void Debug(string content)
        {
            UnityEngine.Debug.Log(content);
        }
        
        public static void Warning(string content)
        {
            UnityEngine.Debug.LogWarning(content);
        }
        
        public static void Error(string content)
        {
            UnityEngine.Debug.LogError(content);
        }
    }
}
