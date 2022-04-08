using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsAPI.Models
{
    public class Report
    {

        public int reportNum { get; set; }

        public string creator { get; set; }
        
        public string offendingComic { get; set; }

        public string offendingUser { get; set; }

        public string infraction { get; set; }

        public DateTime timeStamp { get; set; }
    }
}