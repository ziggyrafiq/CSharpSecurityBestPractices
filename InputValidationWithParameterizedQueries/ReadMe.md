# Input Validation with Parameterized Queries (Preventing SQL Injection)
This repository provides code examples and guidance for implementing input validation with parameterized queries in C# to prevent SQL injection attacks. SQL injection is a critical security vulnerability where attackers can manipulate user input to execute malicious SQL commands and gain unauthorized access to databases.

## Code Example: Validating User Input with Parameterized Queries
In the code example below, we demonstrate how to validate user input and use parameterized queries to prevent SQL injection.
```
using System;
using System.Data.SqlClient;

Console.Write("Enter your username: ");
string inputUsername = Console.ReadLine();

// Validate and sanitize user input
if (!string.IsNullOrWhiteSpace(inputUsername))
{
    // Connect to the database
    string connectionString = "Our_Connection_String_Goes_Here";
    using SqlConnection connection = new SqlConnection(connectionString);

    // Create a parameterized query to prevent SQL injection
    string query = "SELECT * FROM Users WHERE Username = @Username";

    using SqlCommand command = new SqlCommand(query, connection);
    command.Parameters.AddWithValue("@Username", inputUsername);

    try
    {
        connection.Open();
        SqlDataReader reader = command.ExecuteReader();

        // Process the query result...
        while (reader.Read())
        {
            Console.WriteLine(reader["Username"]);
        }
        reader.Close();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}
else
{
    Console.WriteLine("Invalid input. Please enter a valid username.");
}
```
In the code above, we prompt the user to enter a username, and the inputUsername variable stores the user's input. Before executing the SQL query, we validate the input to ensure it is not empty or null. Additionally, we use a parameterized query by adding the @Username parameter to the SQL command. Parameterized queries bind the input value separately from the SQL command, preventing potential SQL injection attacks.

## Security Considerations
Input validation is crucial to prevent SQL injection attacks, but it should not be the only security measure in place. Always follow the principle of least privilege and restrict database user permissions to minimize the impact of potential attacks.

Additionally, consider using an Object-Relational Mapping (ORM) framework like Entity Framework, which handles parameterized queries automatically and provides an additional layer of security.

## Contributing

Contributions to improve and expand the code examples are welcome. Feel free to submit pull requests with enhancements or bug fixes.

## About The Author Ziggy Rafiq 
Ziggy Rafiq is the author and creator of this repository. He is a C# Corner MVP Award recipient in 2023, with over 20 years of technical experience using Microsoft technologies and tools. Ziggy has earned various other awards in the past for his contributions to the tech community.

Please note that these examples are simplified for demonstration purposes. In real-world applications, additional security measures and best practices may be required. It is essential to adapt these practices to the specific requirements and security needs of your application.

We hope these code examples serve as a useful reference for maintaining security in your C# applications. Should you have any questions or feedback, please feel free to reach out.


## License

This code is provided under the MIT License, allowing you to use and modify it freely. Please refer to the License file for more details.

**Happy and Secure Coding!**