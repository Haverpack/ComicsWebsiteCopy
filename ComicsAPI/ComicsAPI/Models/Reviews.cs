using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsAPI.Models
{
    public class Reviews
    {
        public int reportNum { get; set; }

        public string adminID { get; set; }

        public string userID { get; set; }

        public string offendingUser { get; set; }

        public string offendingComic { get; set; }
    }
}