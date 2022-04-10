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
    public class CommunityController : ApiController
    {
        // GET api/values/5
        [HttpGet]
        [Route("community/{name}")]
        public IEnumerable<string> GetCommunityName(string name)
        {

            return new string[] {};
        }

        // POST api/<controller>
        [HttpPost]
        [Route("community")]
        public bool createAdmin(Community community)
        {
            try
            {
                CommunityProcessor.createCommunity(community.name);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        [Route("community")]
        public bool Delete(Community community)
        {
            try
            {
                CommunityProcessor.deleteCommunity(community.name);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}