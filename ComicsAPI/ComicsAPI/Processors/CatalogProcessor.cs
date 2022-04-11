﻿using ComicsAPI.Models;
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
                    return connection.Query<Catalog>($"SELECT * FROM [dbo].[Catalog] WHERE catalogTitle = '{title}'").ToList()[0];
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
                    var query = $"INSERT INTO [dbo].[Catalog] VALUES ('{cat.title}','{cat.communityName}','{cat.creator}')";

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
                    return connection.Query<Comic>($"SELECT * FROM [dbo].[Comic] WHERE comicTitle = '{title}'").ToList()[0];
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
                    var query = $"INSERT INTO [dbo].[Comic] VALUES ('{comic.title}','{comic.pages}','{comic.author}')";

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
            catch
            {
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

        public static bool RemoveChapter(Chapter chapter)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Comic] WHERE chapterNum = {chapter.chapterNum} and comicTitle = {chapter.comicTitle}";

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
        public static Comment GetComment(int commentNum, int chapterNum, string comicTitle)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    return connection.Query<Comment>($"SELECT * FROM [dbo].[Comment] WHERE commentNum = {commentNum} and chapterNum = {chapterNum} and comicTitle = {comicTitle}").ToList()[0];
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
                    var query = $"INSERT INTO [dbo].[Comment] (writer,chapterNum,body,comicTitle) VALUES ('{comment.writer}',{comment.chapterNum},'{comment.body}','{comment.comicTitle}')";

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

        public static bool RemoveComment(int commentNum, int chapterNum, string comicTitle)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"DELETE FROM [dbo].[Comment] WHERE commentNum = {commentNum} and chapterNum = {chapterNum} and comicTitle = '{comicTitle}'";

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

        public static bool EditComment(int commentNum, int chapterNum, string comicTitle, string body)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    var query = $"UPDATE [dbo].[Comment] SET body = {body} WHERE commentNum = {commentNum} and chapterNum = {chapterNum} and comicTitle = '{comicTitle}'";

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