
namespace SecureSessionManagementNative
{
    public static class Security
    {
        private static readonly Dictionary<string, object> SessionData = new Dictionary<string, object>();
        public static void StoreSessionData<T>(string sessionId, string key, T value)
        {
            // Store the session data securely (you might use a more secure storage mechanism in a real application)
            SessionData[$"{sessionId}_{key}"] = value;
        }

        public static T RetrieveSessionData<T>(string sessionId, string key)
        {
            // Retrieve and return the session data securely
            if (SessionData.TryGetValue($"{sessionId}_{key}", out object value) && value is T typedValue)
            {
                return typedValue;
            }

            return default(T);
        }

        public static void ClearSessionData(string sessionId)
        {
            // Clear the session data after session expiration or when the user logs out
            // In this example, we are using a Dictionary, but you might use a more suitable data store for a real application
            SessionData.Clear();
        }
    }
}
