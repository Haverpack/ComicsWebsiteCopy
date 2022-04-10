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
        public IEnumerable<string> TestCommunityExistence(string name)
        {

            return new string[] {};
        }

        // POST api/<controller>
        [HttpPost]
        [Route("community")]
        public bool createCommunity(Community community)
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

        // POST api/<controller>
        [HttpPost]
        [Route("community/forum/{writer}")]
        public bool createForum(Forum forum,string writer)
        {
            try
            {
                CommunityProcessor.createForum(forum, writer);
                return true;
            }
            catch
            {
                return false;
            }
        }

        // POST api/<controller>
        [HttpPost]
        [Route("community/forum/comment/{writer}")]
        public bool commentOnForum(Forum forum, string writer)
        {
            try
            {
                CommunityProcessor.commentOnForum(forum, writer);
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
        public bool DeleteCommunity(Community community)
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

        [HttpDelete]
        [Route("community/forum")]
        public bool DeleteCommunity(Forum forum)
        {
            try
            {
                CommunityProcessor.deleteForum(forum);
                return true;
            }
            catch
            {
                return false;
            }
        }

        [HttpDelete]
        [Route("community/forum/{commentNum}")]
        public bool DeleteComment(Forum forum, int commentNum)
        {
            try
            {
                CommunityProcessor.deleteComment(forum,commentNum);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}