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
    public class AdminController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet]
        [Route("admin/{id}")]
        public IEnumerable<string> GetAdmin(int id)
        {
            Admin desired;
            desired = UserProcessor.GetAdmin(id);

            return new string[] { desired.adminID.ToString(), desired.password };
        }

        // POST api/<controller>
        [HttpPost]
        [Route("admin/{pw}")]
        public bool createAdmin(string pw)
        {
            try
            {
                UserProcessor.CreateAdmin(pw);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // PUT api/<controller>/5
        [HttpPut]
        [Route("admin")]
        public bool updateAdminPW(Admin admin)
        {
            try
            {
                UserProcessor.ModifyAdminPW(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<controller>/5
        [Route("admin")]
        public bool Delete(Admin admin)
        {
            try
            {
                UserProcessor.DeleteAdmin(admin);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}