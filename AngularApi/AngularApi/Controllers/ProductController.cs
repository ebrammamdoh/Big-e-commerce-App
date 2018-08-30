using AngularApi.Models;
using AngularApi.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularApi.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        // GET: api/Product
        ProductBL pro = new ProductBL();
        public IEnumerable<ProductVM> Get()
        {
            return pro.getAllProduct();
        }

        // GET: api/Product/5
        public ProductVM Get(int id)
        {
            return pro.getProductById(id);
        }

        // POST: api/Product
        public int Post([FromBody]ProductVM product)
        {
            return pro.addProduct(product);
        }

        // PUT: api/Product/5
        public IHttpActionResult Put(int id,[FromBody]ProductVM prod)
        {
         
            return Ok<int>(pro.updateProduct(id, prod));
        }

        // DELETE: api/Product/5
        public bool Delete(int id)
        {
            return pro.deleteProduct(id);
        }
    }
}
