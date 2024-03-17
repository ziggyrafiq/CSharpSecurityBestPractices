// Sample password provided by the user (you would get this from a registration or login form)
using SecurePasswordStorageWithSaltedHashing;

string userPassword = "MyStrongPassword123";

// Generate a random salt (unique for each user)
byte[] salt = Security.GenerateSalt();

// Hash the password with the salt
string hashedPassword = Security.HashPassword(userPassword, salt);

// In a real application, you would store 'hashedPassword' and 'salt' in the database
// When the user attempts to login, you'll retrieve the 'salt' from the database and
// recompute the hashed password for the login attempt to compare it with the stored one.