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
    public class UsersController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2", "value3" };
        }

        // GET api/values/5
        /*
        [HttpGet]
        [Route("admin")]
        public IEnumerable<string> GetAdmin(int id)
        {
            Admin desired;
            desired = UserProcessor.GetAdmin(id);

            return new string[] { desired.adminID.ToString(), desired.password };
        }*/

        // POST api/values
        [HttpPost]
        [Route("user")]
        public bool signUp(User user)
        {
            if(user == null)
            {
                return false;
            }

            return UserProcessor.addUser(user);
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
