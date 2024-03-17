// Sample user data (you would get this from a database or identity provider)
using AuthenticationWithOAuth2._0;

string username = "john_smith";
int userId = 123;

// Generate a token for the user using JWT (JSON Web Token) with OAuth 2.0
string token = JwtToken.GenerateJwtToken(username, userId);

// Send the token to the user (e.g., as a response in a web API)
Console.WriteLine($"JWT Token: {token}");