using System.Data.SqlClient;

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