using ComicsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;

namespace ComicsAPI.Processors
{
    public class CatalogProcessor
    {
        //This file will deal with Catalog, Comic, Chapter, Comment models

        //Get, Add, Remove Catalog
        public static Catalog GetCatalog(string title)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Catalog>($"SELECT * FROM [dbo].[Catalog] WHERE title = '{title}'").ToList()[0];
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddCatalog(Catalog cat)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Catalog] (title, commName, creator) VALUES ('{cat.title}','{cat.commName}','{cat.creator}')";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool RemoveCatalog(string title)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Catalog] WHERE title = '{title}'";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //Get, Add, Remove Comic
        public static Comic GetComic(string title)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Comic>($"SELECT * FROM [dbo].[Comic] WHERE title = '{title}'").ToList()[0];
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddComic(Comic comic)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Comic] VALUES ('{comic.title}','{comic.pages}','{comic.author}', '{comic.banner}')";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveComic(string title)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Comic] WHERE title = '{title}'";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        //Get, Add, Remove Chapter
        public static Chapter GetChapter(Chapter chapter)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Chapter>($"SELECT * FROM [dbo].[Chapter] WHERE comicTitle = '{chapter.comicTitle}' and chapterNum = {chapter.chapterNum}").ToList()[0];
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddChapter(Chapter chapter)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Chapter] VALUES ({chapter.chapterNum},'{chapter.comicTitle}')";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool UpdateBanner(Comic comic)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"UPDATE [dbo].[Comic] SET comic.banner = '{comic.banner}' WHERE comic.title = {comic.title}";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();

            }

            return true;
        }

        public static List<Comic> getComicTitles()
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            try
            {
                using (var connection = new SqlConnection(connectionString))
                {

                    string query = $"SELECT * \n" +
                                    "FROM [dbo].[Comic] \n";
                    List<Comic> result = connection.Query<Comic>(query).ToList();
                    return (result);

                }
            } catch
            {
                return (null);
            }
        }

        public static bool RemoveChapter(Chapter chapter)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Chapter] WHERE chapterNum = {chapter.chapterNum} and comicTitle = '{chapter.comicTitle}'";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        //Get, Add, Remove, Modify Comment
        public static Comment GetComment(Comment comment)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Comment>($"SELECT * FROM [dbo].[Comment] WHERE commentNum = {comment.commentNum} and chapterNum = {comment.chapterNum} and writer = {comment.writer}").ToList()[0];
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddComment(Comment comment)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Comment] (writer,chapterNum,body) VALUES ('{comment.writer}',{comment.chapterNum},'{comment.body}')";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool RemoveComment(Comment comment)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Comment] WHERE commentNum = {comment.commentNum} and chapterNum = {comment.chapterNum}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static bool EditComment(Comment comment)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"UPDATE [dbo].[Comment] SET body = '{comment.body}' WHERE commentNum = {comment.commentNum} and chapterNum = {comment.chapterNum}";

                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    command.ExecuteNonQuery();
                    command.Dispose();
                    connection.Close();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public static List<Catalog> GetCommunityCatalog(Community community)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Catalog>($"SELECT * FROM [dbo].[Catalog] WHERE commName = '{community.name}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }
    }
}