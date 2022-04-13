using ComicsAPI.Models;
using ComicsAPI.Processors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace ComicsAPI.Controllers
{
    // REF: 
    // https://stackoverflow.com/questions/21440307/how-to-set-custom-headers-when-using-ihttpactionresult
    public class CustomOkResult<T> : OkNegotiatedContentResult<T>
    {
        public CustomOkResult(T content, ApiController controller) : base(content, controller) { }
        public CustomOkResult(T content, IContentNegotiator contentNegotiator, HttpRequestMessage request,
            IEnumerable<MediaTypeFormatter> formatters) : base(content, contentNegotiator, request, formatters) { }

        public string ETagValue { get; set; }

        public override async Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            HttpResponseMessage response = await base.ExecuteAsync(cancellationToken);

            // 406? string.Format("\"{0}\"", this.ETagValue) || Replace this.ETagValue
            response.Headers.ETag = new System.Net.Http.Headers.EntityTagHeaderValue(string.Format("\"{0}\"", this.ETagValue));

            return(response);
        }
    }
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

        [HttpGet]
        [Route("community/catalog")]
        public List<Catalog> GetCommunityCatalog(Community community)
        {
            return CatalogProcessor.GetCommunityCatalog(community);
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

        [HttpGet]
        [Route("comic")]
        public List<Comic> getComicTitles()
        {
            /*
            return new CustomOkResult<List<Comic>>(content: CatalogProcessor.getComicTitles(), controller: this)
            {
                ETagValue = "ETV1"
            };
            */
            return (CatalogProcessor.getComicTitles());

        }

        [HttpPost]
        [Route("comic/banner")]
        public bool UpdateBanner(Comic comic)
        {
            try
            {
                CatalogProcessor.UpdateBanner(comic);
                return(true);
            } catch
            {
                return(false);
            }
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