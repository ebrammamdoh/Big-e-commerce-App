using AngularApi.Models.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;

namespace AngularApi.Models.Authentication
{
    public class SecurityManager
    {
        public async Task<AppUserAuth> validateUser(AppUser user)
        {
            var userAuth = new AppUserAuth();
            AppUser appUser = null;

            using (var context = new DataContext())
            {
                appUser = context.AppUser.Where(u => u.username.ToLower() == user.username.ToLower()
                && u.password == user.password).FirstOrDefault();
            }
            if (appUser != null)
                userAuth =await createAppUserAuth(user);

            return userAuth;
        }
        private List<AppUserClaim> getUserClaims(AppUser user)
        {
            var claimLst = new List<AppUserClaim>();
            using (var context = new DataContext())
            {
                var userid = context.AppUser.Where(u => u.username == user.username && u.password == user.password).FirstOrDefault().UserId;
                claimLst = context.AppUserClaims.Where(c => c.UserId == userid).ToList();
            }
            return claimLst;
        }
        private async Task<AppUserAuth> createAppUserAuth(AppUser user)
        {
            var userAuth = new AppUserAuth();
            var claims = new List<AppUserClaim>();
            claims = getUserClaims(user);
            foreach (AppUserClaim claim in claims)
            {
                typeof(AppUserAuth).GetProperty(claim.ClaimType)
                    .SetValue(userAuth, Convert.ToBoolean(claim.ClaimValue));
            }
            userAuth.username = user.username;
            userAuth.isAuthenticated = true;
            userAuth.isAdmin = userAuth.isAdmin;
            userAuth.bearerToken = await GetAccessToken(user);

            
            return userAuth;
        }
        private async Task<string> GetAccessToken(AppUser user)
        {
            string baseUri = "http://localhost:3333/token";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseUri);

                // We want the response to be JSON.
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                // Build up the data to POST.
                List<KeyValuePair<string, string>> postData = new List<KeyValuePair<string, string>>();
                postData.Add(new KeyValuePair<string, string>("grant_type", "password"));
                postData.Add(new KeyValuePair<string, string>("username", user.username));
                postData.Add(new KeyValuePair<string, string>("password", user.password));

                FormUrlEncodedContent content = new FormUrlEncodedContent(postData);

                // Post to the Server and parse the response.
                HttpResponseMessage response = await client.PostAsync("token", content);
                string jsonString = await response.Content.ReadAsStringAsync();
                object responseData = JsonConvert.DeserializeObject(jsonString);

                // return the Access Token.
                return  ((dynamic)responseData).access_token;
            }
        }
    }
}