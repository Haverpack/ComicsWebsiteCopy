using ComicsAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ComicsAPI.Processors
{
    public class CommunityProcessor
    {
        //This file will deal with Community, Forum, And FComment Models

        //TODO: Create a moderates relationship between community and person who created 
        public bool createCommunity(string name)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"INSERT INTO [dbo].[Community] VALUES ('{name}')";
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

        public bool deleteCommunity(string name)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"DELETE FROM [dbo].[Community] WHERE name='{name}'";
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

        public bool createForum(Forum forum, string writer)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"INSERT INTO [dbo].[Forum] VALUES ('{forum.communityName}','{forum.title}')";
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();

                    //Create original post for forum 
                    updateQuery = $"INSERT INTO [dbo].[FComment] (writer,forumTitle) VALUES ('{writer}','{forum.title}')";
                    command = new SqlCommand(updateQuery, connection);
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

        //This is to create JUST a comment, not a forum like the above function
        public bool commentOnForum(Forum forum, string writer)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {


                    //Create original post for forum 
                    var updateQuery = $"INSERT INTO [dbo].[FComment] (writer,forumTitle) VALUES ('{writer}','{forum.title}')";
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

        //Try this, not sure if entire primary key needed tbh
        public bool deleteComment(Forum forum, int commentNum)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"DELETE FROM [dbo].[FComment] WHERE forumTitle='{forum}' and commentNum={commentNum}";
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

        public bool deleteForum(Forum forum)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"DELETE FROM [dbo].[Forum] WHERE title='{forum.title}' and communityName='{forum.communityName}'";
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
    }
}