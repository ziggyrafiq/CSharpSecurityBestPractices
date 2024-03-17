using System.Web;

Console.Write("Enter your comment: ");
string inputComment = Console.ReadLine();

// Sanitize user input using HTML encoding
string sanitizedComment = HttpUtility.HtmlEncode(inputComment);

// Store the sanitized comment in the database or display it on a web page
Console.WriteLine($"Sanitized Comment: {sanitizedComment}");
