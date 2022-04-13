using ComicsAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;

/*
 * REF:
 * https://dotnet-helpers.com/mvc/different-way-to-call-controller-from-view-using-mvc-razor/
 * 
*/
namespace ComicsSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Reader()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Main()
        {
            return View();
        }

        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        public ActionResult Community()
        {
            return View();
        }

        [HttpPost]
        public ActionResult htSIN(string userID, string password)
        {
            /*
             * REF:
             * https://stackoverflow.com/questions/1330856/getting-http-status-code-number-200-301-404-etc-from-httpwebrequest-and-ht
             * https://stackoverflow.com/questions/1705442/generate-http-post-request-from-controller
             * https://stackoverflow.com/questions/1949610/how-can-i-catch-a-404
             * https://www.youtube.com/watch?v=EyrKUSwi4uI
             * 
             * COOKIES (TO BE IMPLEMENTED):
             * https://stackoverflow.com/questions/57982185/httpresponse-set-cookies
             * 
            
            string url = "https://localhost:44366/user/{userID}/{password}";

            //Data parameter Example
            //string data = "name=" + value
            string data = "userID=" + userID + "password=" + password;

            HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "application/x-www-form-urlencoded";
            httpRequest.ContentLength = data.Length;
            httpRequest.AllowAutoRedirect = false;

            var streamWriter = new StreamWriter(httpRequest.GetRequestStream());
            streamWriter.Write(data);
            streamWriter.Close();

            HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            

            if(httpResponse.StatusCode.ToString() == "OK")
            {
                return (Main());
            } else
            {
                return (Signup());
            }
            */

            // GET REQUEST -- Above this is POST request (if we ever need it).
            try
            {
                string url = "https://localhost:44366/user/" + userID + "/" + password;
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpRequest.Method = "GET";

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                if (httpResponse.StatusCode.ToString() == "OK")
                {
                    Session["userID"] = userID;
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                // Empty, we just want to continue.
            }

            if (Session["userID"] == null)
            {
                try
                {
                    string url = "https://localhost:44366/admin/" + userID + "/" + password;
                    HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                    httpRequest.Method = "GET";

                    HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                    if (httpResponse.StatusCode.ToString() == "OK")
                    {
                        Session["adminID"] = userID;
                    }
                }
                catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
                {
                    // Empty, we just want to continue.
                } 
                catch (WebException ex1) when ((ex1.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.BadRequest)
                {
                    // Empty, we just want to continue.
                }
            }

            if (Session["userID"] != null || Session["adminID"] != null)
            {
                return (View("Main"));
            } else
            {
                return (View("Signup"));
            }

        }

        public ActionResult htSOUT()
        {
            // Clear session
            Session.Abandon();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult viewComics()
        {
            // REF:
            // https://stackoverflow.com/questions/1259934/store-list-to-session#:~:text=Yes%2C%20you%20can%20store%20any,%22test%22%5D%3B%20%2F%2F%20list.
            try
            {
                string url = "https://localhost:44366/comic/";
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpRequest.Method = "GET";

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                if (httpResponse.StatusCode.ToString() == "OK")
                {
                    /* NOT IT
                    System.Diagnostics.Debug.WriteLine("ResponseCT: " + httpResponse.ContentType + "\n");
                    System.Diagnostics.Debug.WriteLine("ResponseHead: " + httpResponse.Headers + "\n");
                    System.Diagnostics.Debug.WriteLine("ResponseTS: " + httpResponse.ToString() + "\n");
                    */
                    WebHeaderCollection header = httpResponse.Headers;

                    List<Comic> ComicsList;
                    var encoding = ASCIIEncoding.ASCII;
                    using (var reader = new System.IO.StreamReader(httpResponse.GetResponseStream(), encoding))
                    {
                        string parsed = reader.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine("ResponseCT: " + parsed + "\n");

                        List<String> Comics = parsed.Split(new string[] { "{", "}", ",", "[", "]" },
                            StringSplitOptions.RemoveEmptyEntries).ToList();
                        for(int i = 0; i < Comics.Count; i++)
                        {
                            System.Diagnostics.Debug.WriteLine("Index: " + i + " | Contains: " + Comics[i] + "\n");
                        }
                    }
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                // Empty, we just want to continue.
            }
            return (View("Index"));
        }
    }
}