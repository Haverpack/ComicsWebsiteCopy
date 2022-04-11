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
        [Route("catalog")]
        public Catalog GetCatalog(string title)
        {
            return CatalogProcessor.GetCatalog(title);
        }

        [HttpGet]
        [Route("comic")]
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
        public Comment GetComment(int commentNum, int chapterNum, string comicTitle)
        {
            return CatalogProcessor.GetComment(commentNum,chapterNum,comicTitle);
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
        [Route("catalog")]
        public bool RemoveCatalog(string title)
        {
            return CatalogProcessor.RemoveCatalog(title);
        }

        [HttpDelete]
        [Route("comic")]
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
        public bool RemoveComment(int commentNum, int chapterNum, string comicTitle)
        {
            return CatalogProcessor.RemoveComment(commentNum,chapterNum,comicTitle);
        }

        [HttpPut]
        [Route("comic/chapter/comment")]
        public bool EditComment(int commentNum, int chapterNum, string comicTitle, string body)
        {
            return CatalogProcessor.EditComment(commentNum,chapterNum,comicTitle,body);
        }
    }
}