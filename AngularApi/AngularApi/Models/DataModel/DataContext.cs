using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularApi.Models.DataModel
{
    public class DataContext:DbContext
    {
        public DataContext():base("AngularApi")
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public DbSet<AppUserClaim> AppUserClaims { get; set; }
    }
}