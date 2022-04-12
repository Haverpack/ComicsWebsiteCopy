using ComicsAPI.Models;
using ComicsAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using System.Web.Mvc;

namespace ComicsAPI.Controllers
{
    /*
    public class UserControllersMVC : Controller
    {
        [System.Web.Mvc.HttpGet]
        public ActionResult signIn(string userID, string password)
        {
            if (UserProcessor.signIn(userID, password)) {
                return (RedirectToAction("Index"));
            } else {
                return RedirectToAction("Signup");
            }

        }
    }
    */

    public class UsersController : ApiController
    {

        [HttpGet]
        [Route("user/{userID}/{password}")]
        public IHttpActionResult signIn(string userID, string password)
        {
            //return UserProcessor.signIn(userID, password);
            if (UserProcessor.signIn(userID, password))
            {
                return Ok();
            } else
            {
                return NotFound();
            }
            
        }
        
        // GET api/values/5
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("user/{userID}")]
        public IEnumerable<string> GetAdmin(string userID)
        {
            User desired;
            desired = UserProcessor.GetUser(userID);

            return new string[] { desired.userID, desired.email, desired.password };
        }

        // POST api/values
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("user")]
        public void signUp(User user)
        {
            if (user == null)
            {
                //return false;
            }
            UserProcessor.addUser(user);

            //return UserProcessor.addUser(user);
        }

        // PUT api/values/5
        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("user/{oldID}/{newID}")]
        public string UpdateUserName(string oldID, string newID)
        {
            if(oldID == newID)
            {
                return "That name is already set.";
            }
            UserProcessor.ModifyUserName(oldID, newID);
            return $"Set user {oldID} to {newID}";

        }

        [System.Web.Http.HttpPut]
        [System.Web.Http.Route("user")]
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
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("user/{userID}")]
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

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("author/{userID}")]
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
