using System.Diagnostics;

// Sample user input (this could come from a user input field in a web application)
string userInput = "calc.exe";

// Avoid executing dynamic code constructed with user input directly
// In this example, we launch a process based on the user input, but this should be avoided with untrusted input
Process.Start(userInput);