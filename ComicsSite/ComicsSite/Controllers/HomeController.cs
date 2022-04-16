using ComicsAPI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        private string PEntry(string Response)
        {
            string[] parse = Response.Split(':');
            return (parse[1].Trim('"'));
        }

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

        public ActionResult Review()
        {
            return View();
        }

        public ActionResult SetTags()
        {
            return View();
        }

        public ActionResult CreateComic()
        {
            return View();
        }

        public ActionResult UserComics()
        {
            return View();
        }

        //-----------------------------------------------

        public ActionResult FirstPage()
        {
            Session["pageNum"] = 1;
            return View("Reader");
        }

        public ActionResult DecrementPage()
        {
            var temp = (int)Session["pageNum"];
            temp -= 1;
            if (temp < 1)
            {
                temp = 1;
            }
            Session["pageNum"] = temp;
            return View("Reader");
        }

        public ActionResult IncrementPage()
        {
            var temp = (int)Session["pageNum"];
            temp += 1;
            if (!System.IO.File.Exists(Server.MapPath($"~/Images/{Session["CurrentComic"]}/{temp}.png")))
            {
                temp -= 1;
            }
            Session["pageNum"] = temp;
            return View("Reader");
        }
        public ActionResult LastPage()
        {
            var temp = (int)Session["pageNum"];
            while (System.IO.File.Exists(Server.MapPath($"~/Images/{Session["CurrentComic"]}/{temp}.png")))
            {
                temp++;
            }
            temp--;
            Session["pageNum"] = temp;
            return View("Reader");
        }

        [HttpPost]
        public ActionResult SetCurrentComic(string title)
        {
            title = title.Replace(" ", "_");
            Session["CurrentComic"] = title;
            Session["pageNum"] = 1;
            return View("Reader");
        }

        public ActionResult SetCurrentComicFromMain(string title)
        {
            title = title.Replace(" ", "_");
            Session["CurrentComic"] = title;
            Session["pageNum"] = 1;
            return View("Reader");
        }

        //Reference: https://www.c-sharpcorner.com/article/upload-files-in-asp-net-mvc-5/
        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (!Directory.Exists(Server.MapPath($"~/Images/{Session["CurrentComic"]}")))
                {
                    Directory.CreateDirectory(Server.MapPath($"~/Images/{Session["CurrentComic"]}"));
                }
                if (file.ContentLength > 0)
                {
                    string _FileName = "1.png";
                    int i = 1;

                    while (System.IO.File.Exists(Server.MapPath($"~/Images/{Session["CurrentComic"]}/{i}.png")))
                    {
                        i++;
                        _FileName = i.ToString() + ".png";
                    }

                    string _path = Path.Combine(Server.MapPath($"~/Images/{Session["CurrentComic"]}"), _FileName);
                    file.SaveAs(_path);
                }
                ViewBag.Message = "File Uploaded Successfully!!";
                return View("Reader");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View("Reader");
            }
        }

        //-----------------------------------------------

        [HttpPost]
        public ActionResult htSIN(string userID, string password)
        {
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
                        curViewAdminReports(userID, password);
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
                return (viewComics());
            } else
            {
                return (View("Signup"));
            }

        }

        [HttpPost]
        public ActionResult PostCM(string title, string author)
        {
            /*
             * REF:
             * https://www.tutorialsteacher.com/webapi/consume-web-api-post-method-in-aspnet-mvc
             */

            try
            {
                
                string url = "https://localhost:44366/comic";
                Comic CM = new Comic();
                CM.title = title;
                CM.author = author;
                /*
                //Data parameter Example
                //string data = "name=" + value
                var data = Encoding.ASCII.GetBytes(CM);

                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpRequest.Method = "POST";
                httpRequest.ContentType = "raw";
                httpRequest.ContentLength = data.Length;
                httpRequest.AllowAutoRedirect = false;

                var streamWriter = new StreamWriter(httpRequest.GetRequestStream());
                streamWriter.Write(data);
                streamWriter.Close();

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();


                if (httpResponse.StatusCode.ToString() == "OK")
                {
                    return (View("Main"));
                }
                else
                {
                    return (View("Signup"));
                }
                */

                // Using code from Reference above, to POST.
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Comic>("comic", CM);
                    postTask.Wait();

                    var result = postTask.Result;
                    if(result.IsSuccessStatusCode)
                    {
                        SetCurrentComicFromMain(CM.title);
                        return (View("Reader"));
                    } else
                    {
                        return (View("Signup"));
                    }
                }
            } catch (WebException ex) when((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                System.Diagnostics.Debug.WriteLine("FAILED");
            }
            return (View("Signup"));
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
                    List<Comic> ComicsList = new List<Comic>();

                    // REF:
                    // https://stackoverflow.com/questions/3273205/read-text-from-response
                    WebHeaderCollection header = httpResponse.Headers;
                    var encoding = ASCIIEncoding.ASCII;

                    using (var reader = new System.IO.StreamReader(httpResponse.GetResponseStream(), encoding))
                    {
                        string parsed = reader.ReadToEnd();
                        //System.Diagnostics.Debug.WriteLine("ResponseCT: " + parsed + "\n");

                        // REF:
                        // https://stackoverflow.com/questions/46467258/c-sharp-split-string-and-remove-empty-string
                        // https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
                        List<String> Comics = parsed.Split(new string[] { "{", "}", ",", "[", "]" },
                            StringSplitOptions.RemoveEmptyEntries).ToList();
                        for(int i = 0; i < Comics.Count; i+= 4)
                        {
                            //System.Diagnostics.Debug.WriteLine("Index: " + i + " | Contains: " + Comics[i] + "\n");
                            Comic CC = new Comic();
                            CC.title = PEntry(Comics[i]);
                            CC.pages = PEntry(Comics[i + 1]);
                            CC.author = PEntry(Comics[i + 2]);
                            CC.banner = PEntry(Comics[i + 3]);
                            ComicsList.Add(CC);
                        }

                        // Store all comics in Session.
                        Session["allComics"] = ComicsList;
                    }
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                // Empty, we just want to continue.
            }
            return (View("Main"));
        }

        public ActionResult viewCommunities()
        {
            // REF:
            // https://stackoverflow.com/questions/1259934/store-list-to-session#:~:text=Yes%2C%20you%20can%20store%20any,%22test%22%5D%3B%20%2F%2F%20list.
            try
            {
                string url = "https://localhost:44366/community/";
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpRequest.Method = "GET";

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                if (httpResponse.StatusCode.ToString() == "OK")
                {
                    List<Community> CommunityList = new List<Community>();

                    // REF:
                    // https://stackoverflow.com/questions/3273205/read-text-from-response
                    WebHeaderCollection header = httpResponse.Headers;
                    var encoding = ASCIIEncoding.ASCII;

                    using (var reader = new System.IO.StreamReader(httpResponse.GetResponseStream(), encoding))
                    {
                        string parsed = reader.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine("ResponseCT: " + parsed + "\n");

                        // REF:
                        // https://stackoverflow.com/questions/46467258/c-sharp-split-string-and-remove-empty-string
                        // https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
                        List<String> Communities = parsed.Split(new string[] { "{", "}", ",", "[", "]" },
                            StringSplitOptions.RemoveEmptyEntries).ToList();
                        for (int i = 0; i < Communities.Count; i += 2)
                        {
                            Community CC = new Community();
                            CC.name = PEntry(Communities[i]);
                            CC.creator = PEntry(Communities[i + 1]);
                            CommunityList.Add(CC);
                        }

                        // Store all comics in Session.
                        Session["allCommunity"] = CommunityList;
                    }
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                // Empty, we just want to continue.
            }
            return (View("Community"));
        }

        public void curViewAdminReports(string adminID, string password)
        {
            // REF:
            // https://stackoverflow.com/questions/1259934/store-list-to-session#:~:text=Yes%2C%20you%20can%20store%20any,%22test%22%5D%3B%20%2F%2F%20list.
            try
            {
                string url = "https://localhost:44366/report/" + adminID + "/"+ password;
                HttpWebRequest httpRequest = (HttpWebRequest)HttpWebRequest.Create(url);
                httpRequest.Method = "GET";

                HttpWebResponse httpResponse = (HttpWebResponse)httpRequest.GetResponse();

                if (httpResponse.StatusCode.ToString() == "OK")
                {
                    List<Report> assignedReports = new List<Report>();

                    // REF:
                    // https://stackoverflow.com/questions/3273205/read-text-from-response
                    WebHeaderCollection header = httpResponse.Headers;
                    var encoding = ASCIIEncoding.ASCII;

                    using (var reader = new System.IO.StreamReader(httpResponse.GetResponseStream(), encoding))
                    {
                        string parsed = reader.ReadToEnd();
                        System.Diagnostics.Debug.WriteLine("ResponseAR: " + parsed + "\n");

                        // REF:
                        // https://stackoverflow.com/questions/46467258/c-sharp-split-string-and-remove-empty-string
                        // https://docs.microsoft.com/en-us/dotnet/csharp/how-to/parse-strings-using-split
                        List<string> Reports = parsed.Split(new string[] { "{", "}", ",", "[", "]" },
                            StringSplitOptions.RemoveEmptyEntries).ToList();
                        for (int i = 0; i < Reports.Count; i+=6)
                        {
                            System.Diagnostics.Debug.WriteLine("Index: " + i + " | Contains: " + Reports[i] + "\n");
                            Report CR = new Report();
                            CR.reportNum = Int32.Parse(Reports[i].Trim('"'));
                            CR.creator = Reports[i + 1].Trim('"');
                            CR.offendingUser = Reports[i + 2].Trim('"');
                            CR.offendingComic = Reports[i + 3].Trim('"');
                            CR.infraction = Reports[i + 4].Trim('"');
                            CR.timeStamp = DateTime.Parse(Reports[i + 5].Trim('"'));
                            assignedReports.Add(CR);
                        }

                        // Store all comics in Session.
                        Session["allReports"] = assignedReports;
                    }
                }
            }
            catch (WebException ex) when ((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            {
                // Empty, we just want to continue.
            }
        }
    }
}