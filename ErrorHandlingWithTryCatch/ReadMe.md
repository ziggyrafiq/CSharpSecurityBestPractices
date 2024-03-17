# Error Handling with Try-Catch
This repository provides code examples and best practices for implementing error handling in C# using try-catch blocks. Error handling is crucial for gracefully handling exceptions that may occur during program execution and providing meaningful feedback to users or logging for debugging and auditing purposes.

## Code Example: Handling DivideByZeroException
In the code example below, we demonstrate how to handle a DivideByZeroException using a try-catch block.
```
try
{
    // Some code that may throw an exception
    int numerator = 10;
    int denominator = 0;
    int result = numerator / denominator; // This will throw a DivideByZeroException
    Console.WriteLine($"Result: {result}");
}
catch (DivideByZeroException ex)
{
    // Handle the exception gracefully
    Console.WriteLine("An error occurred: Cannot divide by zero.");
    // Log the exception (you can use a logging framework, as shown in the next example)
}
catch (Exception ex)
{
    // Handle any other unexpected exceptions
    Console.WriteLine("An unexpected error occurred.");
    // Log the exception
}
```
In the code above, we attempt to divide numerator by denominator, which will result in a DivideByZeroException since division by zero is not allowed. The catch block for DivideByZeroException handles the exception gracefully by displaying an appropriate error message. The second catch block is a catch-all for any other unexpected exceptions and provides a generic error message.

## Logging the Exception
To enhance error handling and debugging capabilities, it is common practice to log exceptions. In the catch block, you can use a logging framework (e.g., Serilog, NLog, or log4net) to record detailed information about the exception.
```
catch (DivideByZeroException ex)
{
    // Handle the exception gracefully
    Console.WriteLine("An error occurred: Cannot divide by zero.");
    // Log the exception using a logging framework
    logger.Error(ex, "DivideByZeroException occurred.");
}
catch (Exception ex)
{
    // Handle any other unexpected exceptions
    Console.WriteLine("An unexpected error occurred.");
    // Log the exception using a logging framework
    logger.Error(ex, "Unexpected exception occurred.");
}
```
## Security Considerations
When logging exceptions, be cautious not to expose sensitive information in the logged messages. Ensure that sensitive data, such as user input or passwords, is not included in the logged exceptions.

## Contributing

Contributions to improve and expand the code examples are welcome. Feel free to submit pull requests with enhancements or bug fixes.

## About The Author Ziggy Rafiq 
Ziggy Rafiq is the author and creator of this repository. He is a C# Corner MVP Award recipient in 2023, with over 20 years of technical experience using Microsoft technologies and tools. Ziggy has earned various other awards in the past for his contributions to the tech community.

Please note that these examples are simplified for demonstration purposes. In real-world applications, additional security measures and best practices may be required. It is essential to adapt these practices to the specific requirements and security needs of your application.

We hope these code examples serve as a useful reference for maintaining security in your C# applications. Should you have any questions or feedback, please feel free to reach out.


## License

This code is provided under the MIT License, allowing you to use and modify it freely. Please refer to the License file for more details.

**Happy and Secure Coding!**