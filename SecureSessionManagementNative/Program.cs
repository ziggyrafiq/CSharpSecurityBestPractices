using SecureSessionManagementNative;

// Sample user data (you might get this from authentication)
int userId = 123;
string username = "john_doe";

// Generate a unique session ID (you might use a more robust method in a real application)
string sessionId = Guid.NewGuid().ToString();

// Store session data securely (avoid storing sensitive data in the session)
Security.StoreSessionData(sessionId, "UserId", userId);
Security.StoreSessionData(sessionId, "Username", username);

// Retrieve session data (you can do this for each request)
int storedUserId = Security.RetrieveSessionData<int>(sessionId, "UserId");
string storedUsername = Security.RetrieveSessionData<string>(sessionId, "Username");

// Perform actions using the retrieved session data
Console.WriteLine($"User ID: {storedUserId}, Username: {storedUsername}");

// Clear the session after it expires or when the user logs out
Security.ClearSessionData(sessionId);