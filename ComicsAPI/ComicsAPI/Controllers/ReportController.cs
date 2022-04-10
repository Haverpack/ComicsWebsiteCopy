using ComicsAPI.Models;
using ComicsAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ComicsAPI.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        [Route("report/{reportNum}")]
        public IEnumerable<string> GetSingleReport(int reportNum)
        {
            try
            {
                Report rep = ReportsProcessor.GetReportInfo(reportNum);

                return new string[] { rep.reportNum.ToString(), rep.creator,rep.offendingUser,rep.offendingComic,rep.infraction,rep.timeStamp.ToString()};
            }
            catch
            {
                Console.WriteLine("Ran into an error retrieving single report");
                return null;
            }
        }

        [HttpGet]
        [Route("report/{adminID}/{password}")]
        public IEnumerable<string> GetReportsByAdmin(int adminID,string password)
        {
            try
            {
                Admin checkPass = UserProcessor.GetAdmin(adminID);
                if(checkPass.password != password)
                {
                    throw new ArgumentException("passwords do not match");
                }
                List<Report> reports = ReportsProcessor.GetReviewsByAdmin(adminID);

                string[] reportText = new string[reports.Count * 6];

                int i = 0;
                foreach(Report currentRep in reports)
                {
                    reportText[i++] = currentRep.reportNum.ToString();
                    reportText[i++] = currentRep.creator;
                    reportText[i++] = currentRep.offendingUser;
                    reportText[i++] = currentRep.offendingComic;
                    reportText[i++] = currentRep.infraction;
                    reportText[i++] = currentRep.timeStamp.ToString();
                }

                return reportText;
            }
            catch
            {
                return null;
            }
        }

        [HttpPost]
        [Route("user/report/{writer}/{offender}/{infraction}")]
        public void createReportAgainstUser(string writer, string offender, string infraction)
        {
            try
            {
                ReportsProcessor.createReportAgainstUser(writer, offender, infraction);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        [HttpPost]
        [Route("comic/report/{writer}/{offender}/{infraction}")]
        public void createReportAgainstComic(string writer, string offender, string infraction)
        {
            try
            {
                ReportsProcessor.createReportAgainstComic(writer, offender, infraction);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        [HttpDelete]
        [Route("report/{reportNum}")]
        public void removeReport(int reportNum)
        {
            try
            {
                ReportsProcessor.RemoveReport(reportNum);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
       
    }
}