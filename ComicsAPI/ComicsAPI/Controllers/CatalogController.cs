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
    public class CatalogController : ApiController
    {
        [HttpGet]
        [Route("catalog/search/{title}")]
        public Catalog GetCatalog(string title)
        {
            return CatalogProcessor.GetCatalog(title);
        }

        [HttpGet]
        [Route("comic/search/{title}")]
        public Comic GetComic(string title)
        {
            return CatalogProcessor.GetComic(title);
        }

        [HttpGet]
        [Route("comic/chapter")]
        public Chapter GetChapter(Chapter chapter)
        {
            return CatalogProcessor.GetChapter(chapter);
        }

        [HttpGet]
        [Route("comic/chapter/comment")]
        public Comment GetComment(Comment comment)
        {
            return CatalogProcessor.GetComment(comment);
        }

        [HttpPost]
        [Route("catalog")]
        public bool AddCatalog(Catalog catalog)
        {
            return CatalogProcessor.AddCatalog(catalog);
        }

        [HttpPost]
        [Route("comic")]
        public bool AddComic(Comic comic)
        {
            return CatalogProcessor.AddComic(comic);
        }

        [HttpPost]
        [Route("comic/chapter")]
        public bool AddChapter(Chapter chapter)
        {
            return CatalogProcessor.AddChapter(chapter);
        }

        [HttpPost]
        [Route("comic/chapter/comment")]
        public bool AddComment(Comment comment)
        {
            return CatalogProcessor.AddComment(comment);
        }

        [HttpDelete]
        [Route("catalog/delete/{title}")]
        public bool RemoveCatalog(string title)
        {
            return CatalogProcessor.RemoveCatalog(title);
        }

        [HttpDelete]
        [Route("comic/delete/{title}")]
        public bool RemoveComic(string title)
        {
            return CatalogProcessor.RemoveComic(title);
        }

        [HttpDelete]
        [Route("comic/chapter")]
        public bool RemoveChapter(Chapter chapter)
        {
            return CatalogProcessor.RemoveChapter(chapter);
        }

        [HttpDelete]
        [Route("comic/chapter/comment")]
        public bool RemoveComment(Comment comment)
        {
            return CatalogProcessor.RemoveComment(comment);
        }

        [HttpPut]
        [Route("comic/chapter/comment")]
        public bool EditComment(Comment comment)
        {
            return CatalogProcessor.EditComment(comment);
        }
    }
}