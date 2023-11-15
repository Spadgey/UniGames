using Microsoft.Data.SqlClient;
using UniGames.Data.Models;

namespace UniGames.Data

{
    
    public class UserReviewRepository
    {
        static string connectionString = @"Data Source=.\Localhost;Initial Catalog=UniGames;Integrated Security=True;TrustServerCertificate=true";

        public List<UserReview> GetAllUserReview()
        {
            try
            {
                List<UserReview> UserReview = new List<UserReview>();

                // Create the SqlConnection
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Your SQL query
                    string sqlQuery = "SELECT Game,Platform,User,Review FROM UserReview";

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
                                    string game = reader["Game"].ToString();
                                    string platform = reader["Platform"].ToString();
                                    string User = reader["User"].ToString();
                                    string Review = reader["Review"].ToString();

                                    UserReview.Add(new UserReview(game, platform, User,Review));
                                }
                            }
                            else
                            {
                                Console.WriteLine("No data found.");
                            }
                        }
                    }
                }

                return UserReview;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                throw;
            }
        }

        public IEnumerable<UserReview> GetUserReview()
        {
            throw new NotImplementedException();
        }
    }
}