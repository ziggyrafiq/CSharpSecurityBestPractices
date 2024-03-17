# Using Parameterized Queries (Preventing SQL Injection)
This repository provides code examples and guidance for using parameterized queries to prevent SQL injection attacks in C#. SQL injection is a common web application vulnerability where an attacker can manipulate SQL queries through user input, potentially leading to unauthorized access or data leakage.

## Code Example: Using Parameterized Queries with SQL Server
In the code example below, we demonstrate how to use parameterized queries with SQL Server to safely execute SQL commands without directly concatenating user input into the query.
```
using System;
using System.Data.SqlClient;

public class ParameterizedQueriesExample
{
    public static void Main()
    {
        // Sample user input (this could come from a user input field in a web application)
        string userInput = "John'; DROP TABLE Users; --";

        // Connect to the database (replace connection string with your database details)
        string connectionString = "Data Source=myServerAddress;Initial Catalog=myDatabase;User ID=myUsername;Password=myPassword;";
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            connection.Open();

            // Avoid direct concatenation of user input into the query
            string query = "SELECT * FROM Users WHERE Username = @Username";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Use SqlParameter to add user input as a parameter to the query
                command.Parameters.AddWithValue("@Username", userInput);

                // Execute the query
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Process the query results
                        Console.WriteLine($"User ID: {reader["UserID"]}, Username: {reader["Username"]}");
                    }
                }
            }
        }
    }
}
```
## Security Considerations
* Always use parameterized queries or prepared statements to pass user input to SQL commands. This prevents SQL injection by treating user input as data rather than executable code.
* Avoid directly concatenating user input into SQL queries, as it can lead to SQL injection vulnerabilities.
* Validate and sanitize user input to prevent other types of security vulnerabilities, such as cross-site scripting (XSS) attacks.

## Contributing

Contributions to improve and expand the code examples are welcome. Feel free to submit pull requests with enhancements or bug fixes.

## About The Author Ziggy Rafiq 
Ziggy Rafiq is the author and creator of this repository. He is a C# Corner MVP Award recipient in 2023, with over 20 years of technical experience using Microsoft technologies and tools. Ziggy has earned various other awards in the past for his contributions to the tech community.

Please note that these examples are simplified for demonstration purposes. In real-world applications, additional security measures and best practices may be required. It is essential to adapt these practices to the specific requirements and security needs of your application.

We hope these code examples serve as a useful reference for maintaining security in your C# applications. Should you have any questions or feedback, please feel free to reach out.


## License

This code is provided under the MIT License, allowing you to use and modify it freely. Please refer to the License file for more details.

**Happy and Secure Coding!**