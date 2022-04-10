﻿using ComicsAPI.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ComicsAPI.Processors
{
    public class ReportsProcessor
    {
        public Report GetReportInfo(int reportNum)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Report>($"SELECT * FROM [dbo].[Report] WHERE reportNum = {reportNum}").ToList()[0];
            }
        }

        public List<Report> GetReviewsByAdmin(int adminID)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";

            using (var connection = new SqlConnection(connectionString))
            {
                List<Reviews> reviewsList = connection.Query<Reviews>($"SELECT * FROM [dbo].[Reviews] WHERE adminID = {adminID}").ToList();

                List<Report> importantInfo = new List<Report>();

                foreach(Reviews currentRev in reviewsList)
                {
                    importantInfo.Add(connection.Query<Report>($"SELECT * From [dbo].[Report] WHERE reportNum = {currentRev.reportNum}").ToList()[0]);
                }

                return importantInfo;

            }
        }

        public bool createReportAgainstUser(string offender, string infraction)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                 
                var updateQuery = $"INSERT INTO [dbo].[Report] (offendingUser,infraction) VALUES ('{offender}','{infraction}')";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //return true;

            }

            return true;
        }

        public bool createReportAgainstComic(string offender, string infraction)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"INSERT INTO [dbo].[Report] (offendingComic,infraction) VALUES ('{offender}','{infraction}')";
                connection.Open();
                SqlCommand command = new SqlCommand(updateQuery, connection);
                command.ExecuteNonQuery();
                command.Dispose();
                connection.Close();
                //return true;

            }

            return true;
        }
        public bool RemoveReport(int reportNum)
        {
            var connectionString = "Data Source=(localdb)\\ProjectsV13;Initial Catalog=ComicsDB;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {

                var updateQuery = $"DELETE FROM [dbo].[Report] WHERE reportNum = {reportNum}";
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