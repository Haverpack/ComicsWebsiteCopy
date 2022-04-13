using ComicsAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Dapper;
using System.Data.SqlClient;

namespace ComicsAPI.Processors
{
    public class ConnectionsProcessor
    {
        //Deals with Subscribes, Moderates, Member_of, Collection_of, Catalog_tag, and Comic_tag relations

        public static List<User> GetSubscribers(string title)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<User>($"SELECT userID FROM [dbo].[Subscribes] WHERE comicTitle = '{title}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<Comic> GetSubscriptions(string userID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Comic>($"SELECT comicTitle as title FROM [dbo].[Subscribes] WHERE userID = '{userID}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddSubscriptions(Subscribes toAdd)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Subscribes] VALUES ('{toAdd.comicTitle}','{toAdd.userID}')";

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

        public static List<User> GetModerators(string name)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<User>($"SELECT userID FROM [dbo].[Moderates] WHERE commName = '{name}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<User> GetMembers(string name)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<User>($"SELECT userID FROM Member_Of WHERE commName = '{name}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddMember(Member_Of toAdd)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Member_Of] VALUES ('{toAdd.commName}','{toAdd.userID}')";

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

        public static bool AddModerator(Moderates toAdd)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Moderates] VALUES ('{toAdd.commName}','{toAdd.userID}')";

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

        public static List<Community> GetCommunities(string userID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Community>($"SELECT commName as name FROM [dbo].[Member_Of] WHERE userID = '{userID}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<Comic> GetCatalogContents(string catalogTitle)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Comic>($"SELECT comicTitle as title FROM [dbo].[Collection_Of] WHERE catalogTitle = '{catalogTitle}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static bool AddComicToCat(Collection_Of toAdd)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Collection_Of] VALUES ('{toAdd.catalogTitle}','{toAdd.comicTitle}')";

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

        public static List<Catalog_Tag> GetCatalogTags(string catalogTitle)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Catalog_Tag>($"SELECT tag FROM [dbo].[Catalog_Tag] WHERE catalogTitle = '{catalogTitle}'").ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public static List<Comic_Tag> GetComictags(string comicTitle)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Comic_Tag>($"SELECT tag FROM [dbo].[Comic_Tag] WHERE comicTitle = '{comicTitle}'").ToList();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static string[] GetComicByTags(string[] tags)
        {
            string joined = String.Join(",", tags);
            string joined2 = string.Join(",", joined.Split(',').Select(x => string.Format("'{0}'", x)).ToList());

            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT c.title as comicTitle\n" +
                                   "FROM[dbo].[Comic_Tag] ct\n" +
                                   "JOIN[dbo].[Comic] c ON ct.comicTitle = c.title\n" +
                                   $"WHERE ct.tag IN ({joined2})\n" +
                                   "GROUP BY c.title\n" +
                                   $"HAVING COUNT(DISTINCT ct.tag) = {tags.Count()}\n";
                    List<Comic_Tag> result = connection.Query<Comic_Tag>(query).ToList();

                    string[] toReturn = new string[result.Count];

                    for (int i = 0; i < result.Count; i++)
                    {
                        toReturn[i] = result[i].comicTitle;
                    }

                    return toReturn;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static string[] GetCatalogByTags(string[] tags)
        {
            string joined = String.Join(",", tags);
            string joined2 = string.Join(",", joined.Split(',').Select(x => string.Format("'{0}'", x)).ToList());

            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT c.title as catalogTitle\n" +
                                   "FROM[dbo].[Catalog_Tag] ct\n" +
                                   "JOIN[dbo].[Catalog] c ON ct.catalogTitle = c.title\n" +
                                   $"WHERE ct.tag IN ({joined2})\n" +
                                   "GROUP BY c.title\n" +
                                   $"HAVING COUNT(DISTINCT ct.tag) = {tags.Count()}\n";
                    List<Catalog_Tag> result = connection.Query<Catalog_Tag>(query).ToList();

                    string[] toReturn = new string[result.Count];

                    for (int i = 0; i < result.Count; i++)
                    {
                        toReturn[i] = result[i].catalogTitle;
                    }

                    return toReturn;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static string[] GetTop15Comics()
        {

            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT TOP 15 title FROM [dbo].[Comic] ORDER BY title";
                    List<Comic> result = connection.Query<Comic>(query).ToList();

                    string[] toReturn = new string[result.Count];

                    for (int i = 0; i < result.Count; i++)
                    {
                        toReturn[i] = result[i].title;
                    }

                    return toReturn;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }

        public static bool AddCatalogTags(Catalog_Tag catTag)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Catalog_Tag] VALUES ('{catTag.catalogTitle}','{catTag.tag}')";

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

        public static bool AddComictags(Comic_Tag comTag)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"INSERT INTO [dbo].[Comic_Tag] VALUES ('{comTag.comicTitle}','{comTag.tag}')";

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

        public static bool DeleteComicTag(Comic_Tag comTag)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Comic_Tag] WHERE comicTitle = '{comTag.comicTitle}' and tag = '{comTag.tag}'";

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

        public static bool DeleteCatalogTag(Catalog_Tag catTag)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Catalog_Tag] WHERE catalogTitle = '{catTag.catalogTitle}' and tag = '{catTag.tag}'";

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

        public static bool RemoveMod(Moderates mod)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Moderates] WHERE commName = '{mod.commName}' and userID = '{mod.userID}'";

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

        public static bool RemoveMember(Member_Of member)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Member_Of] WHERE commName = '{member.commName}' and userID = '{member.userID}'";

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

        public static bool RemoveSubscription(Subscribes subscription)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Subscribes] WHERE comicTitle = '{subscription.comicTitle}' and userID = '{subscription.userID}'";

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

        public static bool RemoveFromCatalog(Collection_Of collection)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Collection_Of] WHERE comicTitle = '{collection.comicTitle}' and catalogTitle = '{collection.catalogTitle}'";

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
    }
}