using ComicsAPI.Models;
using ComicsAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;

namespace ComicsAPI.Controllers
{
    public class ConnectionsController : ApiController
    {
        [HttpGet]
        [Route("subscriptions/users/{title}")]
        public List<User> GetSubscribers(string title)
        {
            return ConnectionsProcessor.GetSubscribers(title);
        }

        [HttpGet]
        [Route("subscriptions/comics/{userID}")]
        public List<Comic> GetSubscriptions(string userID)
        {
            return ConnectionsProcessor.GetSubscriptions(userID);
        }

        [HttpGet]
        [Route("community/mods/{name}")]
        public List<User> GetMods(string name)
        {
            return ConnectionsProcessor.GetModerators(name);
        }

        [HttpGet]
        [Route("community/members/{name}")]
        public List<User> GetMembers(string name)
        {
            return ConnectionsProcessor.GetMembers(name);
        }

        [HttpGet]
        [Route("user/search/communities/{userID}")]
        public List<Community> GetCommunities(string userID)
        {
            return ConnectionsProcessor.GetCommunities(userID);
        }

        [HttpGet]
        [Route("catalog/comics/{title}")]
        public List<Comic> GetCatContents(string title)
        {
            return ConnectionsProcessor.GetCatalogContents(title);
        }

        [HttpGet]
        [Route("catalog/tags/{title}")]
        public List<Catalog_Tag> GetCatalogTags(string title)
        {
            return ConnectionsProcessor.GetCatalogTags(title);
        }

        [HttpGet]
        [Route("comics/tags/{title}")]
        public List<Comic_Tag> GetComicTags(string title)
        {
            return ConnectionsProcessor.GetComictags(title);
        }

        //------------------------------------------------------
        //TESTING
        [HttpGet]
        [Route("comics/tags")]
        [EnableCors(origins: "https://localhost:44352", headers: "*", methods: "*")]
        public JsonResult<string[]> SortByComicTags([FromUri] string[] tags)
        {
            return Json<string[]>(ConnectionsProcessor.GetComicByTags(tags));
        }

        [HttpGet]
        [Route("catalogs/tags")]
        [EnableCors(origins: "https://localhost:44352", headers: "*", methods: "*")]
        public JsonResult<string[]> SortByCatalogTags([FromUri] string[] tags)
        {
            return Json<string[]>(ConnectionsProcessor.GetCatalogByTags(tags));
        }

        [HttpGet]
        [Route("comics/list")]
        [EnableCors(origins: "https://localhost:44352", headers: "*", methods: "*")]
        public JsonResult<string[]> GetTop15()
        {
            return Json<string[]>(ConnectionsProcessor.GetTop15Comics());
        }
        //------------------------------------------------------

        [HttpPost]
        [Route("subscriptions")]
        public bool AddSubscriptions(Subscribes toAdd)
        {
            return ConnectionsProcessor.AddSubscriptions(toAdd);
        }

        [HttpPost]
        [Route("community/members")]
        public bool AddMember(Member_Of toAdd)
        {
            return ConnectionsProcessor.AddMember(toAdd);
        }

        [HttpPost]
        [Route("community/mods")]
        public bool AddModerator(Moderates toAdd)
        {
            return ConnectionsProcessor.AddModerator(toAdd);
        }

        [HttpPost]
        [Route("catalog/comics")]
        public bool AddComicToCatalog(Collection_Of toAdd)
        {
            return ConnectionsProcessor.AddComicToCat(toAdd);
        }

        [HttpPost]
        [Route("catalog/tag")]
        public bool AddCatalogTag(Catalog_Tag toAdd)
        {
            return ConnectionsProcessor.AddCatalogTags(toAdd);
        }

        [HttpPost]
        [Route("comic/tag")]
        public bool AddComicTag(Comic_Tag toAdd)
        {
            return ConnectionsProcessor.AddComictags(toAdd);
        }

        [HttpDelete]
        [Route("subscriptions/users")]
        public bool RemoveSub(Subscribes toDel)
        {
            return ConnectionsProcessor.RemoveSubscription(toDel);
        }

        [HttpDelete]
        [Route("community/members")]
        public bool RemoveMember(Member_Of toDel)
        {
            return ConnectionsProcessor.RemoveMember(toDel);
        }

        [HttpDelete]
        [Route("community/mods")]
        public bool RemoveMod(Moderates toDel)
        {
            return ConnectionsProcessor.RemoveMod(toDel);
        }

        [HttpDelete]
        [Route("comic/tag")]
        public bool RemoveComicTag(Comic_Tag toDel)
        {
            return ConnectionsProcessor.DeleteComicTag(toDel);
        }

        [HttpDelete]
        [Route("catalog/tag")]
        public bool RemoveCatalogTag(Catalog_Tag toDel)
        {
            return ConnectionsProcessor.DeleteCatalogTag(toDel);
        }

        [HttpDelete]
        [Route("catalog/comics")]
        public bool RemoveComicFromCat(Collection_Of toDel)
        {
            return ConnectionsProcessor.RemoveFromCatalog(toDel);
        }
    }
}