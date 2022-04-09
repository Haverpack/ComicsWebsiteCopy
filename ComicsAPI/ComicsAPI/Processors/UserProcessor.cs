using ComicsAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ComicsAPI.Processors
{
    public class UserProcessor
    {
        public static bool addUser(User user)
        {
            //String that specifies which DB to connect to
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            //String which specifies query
            var query = "INSERT INTO [dbo].[User] (userID, email, password) VALUES ('@userID','@email','@password')";

            query = query.Replace("@userID",user.userID)
                .Replace("@email",user.email)
                .Replace("@password",user.password);

            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static User GetUser(string userID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<User>($"SELECT * FROM [dbo].[User] WHERE userID = '{userID}'").ToList()[0];
            }
        }

        public static Admin GetAdmin(int id)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Admin>($"SELECT * FROM dbo.Admin WHERE adminID = {id}").ToList()[0];
            }
        }

        public static bool ModifyUserName(string oldID, string newID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"UPDATE [dbo].[User] SET userID = '{newID}' WHERE userID = '{oldID}'";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //return true;

            }

            return true;
        }
    }
}