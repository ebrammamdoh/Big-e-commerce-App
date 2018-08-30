using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularApi.Models.Authentication
{
    public class AppUserAuth
    {
        public AppUserAuth():base()
        {
            username = "";
            bearerToken = string.Empty;
        }
        public string username {get; set; }
        public bool isAdmin { get; set; }
        public string bearerToken { get; set; }
        public bool isAuthenticated { get; set; }

        public bool canAddProduct { get; set; }
        public bool canAddCategory { get; set; }
        public bool candEditProduct { get; set; }
        public bool canEditCategory { get; set; }
        public bool canDeleteProduct { get; set; }
        public bool canDeleteCategory { get; set; }

        
    }
}