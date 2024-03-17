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