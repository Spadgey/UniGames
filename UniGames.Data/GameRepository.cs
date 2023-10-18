using Microsoft.Data.SqlClient;
using UniGames.Data.Models;

namespace UniGames.Data
{
    public class GameRepository
    {
        static string connectionString = "Data Source=localhost;Initial Catalog=UniGames;Integrated Security=True;TrustServerCertificate=true";
    
        public List<Game> GetGames()
        {
            try
            {
                List<Game> games = new List<Game>();
                
                // Create the SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Your SQL query
                    string sqlQuery = "SELECT Title, Platform, Score FROM Games";

                    // Create the SqlCommand with the SQL query and the SqlConnection
                    using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                    {
                        // Execute the query and get the results
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Check if there are any rows returned
                            if (reader.HasRows)
                            {
                                // Read and process each row
                                while (reader.Read())
                                {
                                    string title = reader["Title"].ToString();
                                    string platform = reader["Platform"].ToString();
                                    short score = (short)reader["Score"];
                                    
                                    games.Add(new Game(title, platform, score));
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found.");
                            }
                        }
                    }
                }

                return games;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }
    }
}