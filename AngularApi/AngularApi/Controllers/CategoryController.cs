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
    public class CategoryController : ApiController
    {
        // GET: api/Category
        CategoryBL cat = new CategoryBL();
        public IEnumerable<CategoryVM> Get()
        {
            return cat.getAllCategories();
        }

        // POST: api/Category
        public IHttpActionResult Post([FromBody]CategoryVM cat)
        {
            int id = this.cat.Add(cat);

            return Created<CategoryVM>("http:/locathost:3333/Category/"+id, cat);
        }

        // PUT: api/Category/5
        public int Put(int id, [FromBody]CategoryVM category)
        {
            return cat.updateCategory(category);
        }

        // DELETE: api/Category/5
        public void Delete(int id)
        {
            cat.deleteCategory(id);
        }
    }
}
