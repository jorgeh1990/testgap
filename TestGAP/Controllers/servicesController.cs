using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TestGAP.Models;

namespace TestGAP.Controllers
{
    [BasicAuthorize]
    public class servicesController : ApiController
    {
        private Context db = new Context();
        [Route("api/{controller}/stores")]
        [HttpGet]
        public HttpResponseMessage stores()
        {
            var stores = (from store in db.Stores select new { store.Id, store.address, store.name }).ToList();
            var resp = new { stores, success = true, total_elements = stores.Count };
            return Request.CreateResponse<Object>(HttpStatusCode.OK, resp);
        }

        [Route("api/{controller}/articles/")]
        [HttpGet]
        public HttpResponseMessage articles()
        {
            var articles = (from article in db.Articles select new { article.Id, article.name, article.price, article.total_in_shelf, article.total_in_vault, store_name = article.Store.name, article.StoreId }).ToList();
            var resp = new { articles, success = true, total_elements = articles.Count };
            return Request.CreateResponse<Object>(HttpStatusCode.OK, resp);
        }

        [Route("api/{controller}/articles/stores/{id}")]
        [HttpGet]
        public HttpResponseMessage stores(String id)
        {
            Object resp = null;
            int id_num;
            if (int.TryParse(id, out id_num))
            {
                var articles = (from article in db.Articles where article.StoreId == id_num select new { article.Id, article.name, article.price, article.total_in_shelf, article.total_in_vault, store_name = article.Store.name, article.StoreId }).ToList();
                if (!articles.Count.Equals(0))
                {
                    resp = new { articles, success = true, total_elements = articles.Count };
                }
                else
                {
                    resp = new { error_msg = "Record not Found", error_code = HttpStatusCode.NotFound, success = false };

                }
            }
            else
            {

                resp = new { error_msg = "Bad Request", error_code = HttpStatusCode.BadRequest, success = false };
            }

            return Request.CreateResponse<Object>(HttpStatusCode.OK, resp);
        }
    }
}
