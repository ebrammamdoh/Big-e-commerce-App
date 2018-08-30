using AngularApi.Models.Authentication;
using AngularApi.Models.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace AngularApi.Controllers
{
    public class SecurityController : ApiController
    {
        [HttpPost]
        public async Task<IHttpActionResult> Login([FromBody]AppUser user)
        {
           
            SecurityManager manger = new SecurityManager();
            AppUserAuth authUser = new AppUserAuth();
            //IHttpActionResult res = null;
            authUser =await manger.validateUser(user);
            if(authUser.isAuthenticated)
            {
                return Ok<AppUserAuth>(authUser);
            }
            return BadRequest("Invalid username or password");
        }

    }
}
