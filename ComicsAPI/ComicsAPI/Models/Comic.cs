using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsAPI.Models
{
    public class Comic
    {
        public string title { get; set; }

        public string pages { get; set; } //I'm assuming we'll be storing the path to the pages?

        public string author { get; set; }

    }
}