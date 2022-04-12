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

        public static bool createCommunity(Community community)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"INSERT INTO [dbo].[Community] VALUES ('{community.name}')";
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    ConnectionsProcessor.AddMember(new Member_Of {commName=community.name,userID=community.creator });
                    ConnectionsProcessor.AddModerator(new Moderates { commName = community.name, userID = community.creator });

                }
                return true;
            }
            catch
            {
                return false;
            }

        }

        public static bool deleteCommunity(string name)
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

        public static bool createForum(Forum forum, string writer, string body)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    var updateQuery = $"INSERT INTO [dbo].[Forum] VALUES ('{forum.title}','{forum.communityName}')";
                    connection.Open();
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();

                    //Create original post for forum 
                    updateQuery = $"INSERT INTO [dbo].[FComment] (forumTitle,writer,body,commName) VALUES ('{forum.title}','{writer}','{body}','{forum.communityName}')";
                    command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();

                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //This is to create JUST a comment, not a forum like the above function
        public static bool commentOnForum(Forum forum, string writer,string body)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (var connection = new SqlConnection(connectionString))
                {


                    //Create original post for forum 
                    connection.Open();
                    var updateQuery = $"INSERT INTO [dbo].[FComment] (forumTitle,writer,body,commName) VALUES ('{forum.title}','{writer}','{body}','{forum.communityName}')";
                    SqlCommand command = new SqlCommand(updateQuery, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();

                    connection.Close();

                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

        //Try this, not sure if entire primary key needed tbh
        public static bool deleteComment(Forum forum, int commentNum)
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

        public static bool deleteForum(Forum forum)
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