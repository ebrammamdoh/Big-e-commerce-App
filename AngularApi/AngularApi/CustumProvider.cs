using System.Threading.Tasks;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using AngularApi.Models.DataModel;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin.Security;

namespace AngularApi
{
    internal class CustumProvider : OAuthAuthorizationServerProvider
    {
        public async override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        public async override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            using (var db = new DataContext())
            {
                if (db != null)
                {
                    var users = db.AppUser.ToList();
                    if (users != null)
                    {
                        if (!string.IsNullOrEmpty(users.Where(u => u.username == context.UserName && u.password == context.Password).FirstOrDefault().username))
                        {
                            //identity.AddClaim(new Claim("Age", "16"));

                            //var props = new AuthenticationProperties(new Dictionary<string, string>
                            //{
                            //    {
                            //        "userdisplayname", context.UserName
                            //    },
                            //    {
                            //         "role", "admin"
                            //    }
                            // });

                            var ticket = new AuthenticationTicket(identity,new AuthenticationProperties());
                            context.Validated(ticket);
                        }
                        else
                        {
                            context.SetError("invalid_grant", "Provided username and password is incorrect");
                            context.Rejected();
                        }
                    }
                }
                else
                {
                    context.SetError("invalid_grant", "Provided username and password is incorrect");
                    context.Rejected();
                }
                return;
            }

        }
    }
}