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
        
        // GET api/values/5
        [HttpGet]
        [Route("user/{userID}")]
        public IEnumerable<string> GetAdmin(string userID)
        {
            User desired;
            desired = UserProcessor.GetUser(userID);

            return new string[] { desired.userID, desired.email, desired.password };
        }

        // POST api/values
        [HttpPost]
        [Route("user")]
        public bool signUp(User user)
        {
            if (user == null)
            {
                return false;
            }

            return UserProcessor.addUser(user);
        }

        // PUT api/values/5
        [HttpPut]
        [Route("user/{oldID}/{newID}")]
        public string UpdateUserName(string oldID, string newID)
        {
            if(oldID == newID)
            {
                return "That name is already set.";
            }
            UserProcessor.ModifyUserName(oldID, newID);
            return $"Set user {oldID} to {newID}";

        }

        [HttpPut]
        [Route("user")]
        public string UpdateUserPW(User user)
        {
            try
            {
                UserProcessor.ModifyUserPW(user);
                return "Succesfully updated user password";
            }
            catch
            {
                return "Error when attempting to modify password (Does this account exist?).";
            }
        }

        // DELETE api/values/5
        [HttpDelete]
        [Route("user/{userID}")]
        public string Delete(string userID)
        {
            try
            {
                UserProcessor.DeleteUser(userID);
                return "Succesfully updated user password";
            }
            catch
            {
                return "Error when attempting to modify password (Does this account exist?).";
            }
        }

        [HttpPost]
        [Route("author/{userID}")]
        public bool makeUserAuthor(string userID)
        {
            try
            {
                UserProcessor.CreateAuthor(userID);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
