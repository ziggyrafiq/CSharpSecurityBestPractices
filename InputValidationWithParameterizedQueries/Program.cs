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