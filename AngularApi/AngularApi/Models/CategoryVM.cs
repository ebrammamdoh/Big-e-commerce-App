using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularApi.Models
{
    public class CategoryVM
    {
        public int C_id { get; set; }
        public string C_name { get; set; }
        public int C_products { get; set; }
    }
}