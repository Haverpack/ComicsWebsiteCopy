using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ComicsAPI.Models
{
    public class User
    {
        public string password { get; set;}

        public string email { get; set; }

        public string userID { get; set; }
    }
}