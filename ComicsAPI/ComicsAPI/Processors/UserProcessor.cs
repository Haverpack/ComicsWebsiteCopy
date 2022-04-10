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
        public static bool signIn(string user, string pw)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                List<User> check = connection.Query<User>($"SELECT * FROM [dbo].[User] WHERE userID = '{user}' and password = '{pw}'").ToList();
                if(check.Count == 0)
                {
                    return false;
                }
                return true;
            }
        }

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

        public static bool ModifyUserPW(User user)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"UPDATE [dbo].[User] SET password = '{user.password}' WHERE userID = '{user.userID}'";
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool DeleteUser(string userID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"DELETE FROM [dbo].[User] WHERE userID = '{userID}'";
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                }
                return true;
            }
            catch
            {
                return false;
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

        public static bool CreateAdmin(string pw)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"INSERT INTO [dbo].[Admin] VALUES ('{pw}')";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //return true;

            }

            return true;
        }

        public static bool ModifyAdminPW(Admin admin)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"UPDATE [dbo].[Admin] SET admin.password = '{admin.password}' WHERE admin.adminID = {admin.adminID}";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //return true;

            }

            return true;
        }

        public static bool DeleteAdmin(Admin admin)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"DELETE FROM [dbo].[Admin] WHERE adminID = {admin.adminID}";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //return true;

            }

            return true;
        }


        public static bool CreateAuthor(string userID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"INSERT INTO [dbo].[Author] VALUES ('{userID}')";
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