using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsAPI.Models
{
    public class FComment
    {
        public int commentNum { get; set; }
        public string writer { get; set; }
        public string forumTitle { get; set; }

        public DateTime timeStamp { get; set; }

        public string body { get; set; }

    }
}