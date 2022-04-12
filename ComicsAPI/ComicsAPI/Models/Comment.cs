using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsAPI.Models
{
    public class Comment
    {
        public int commentNum { get; set; }

        public string writer { get; set; }

        public int chapterNum { get; set; }

        public DateTime Timestamp { get; set; }

        public string body { get; set; }

        public string comicTitle { get; set; }
    }
}