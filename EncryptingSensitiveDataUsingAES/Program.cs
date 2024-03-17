// Sample sensitive data to be encrypted
using EncryptingSensitiveDataUsingAES;

string sensitiveData = "This is my sensitive data.";

// Encrypt the sensitive data
string encryptedData = Security.EncryptAES(sensitiveData, "yourEncryptionKey");

// Decrypt the encrypted data (for demonstration purposes)
string decryptedData = Security.DecryptAES(encryptedData, "yourEncryptionKey");

// Output the results
Console.WriteLine($"Original Data: {sensitiveData}");
Console.WriteLine($"Encrypted Data: {encryptedData}");
Console.WriteLine($"Decrypted Data: {decryptedData}");