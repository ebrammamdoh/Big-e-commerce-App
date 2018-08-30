using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularApi.Models
{
    public class ProductVM
    {
        public int C_id { get; set; }
        public string name { get; set; }
        public string code { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> qty { get; set; }
        public Nullable<decimal> rate { get; set; }
        public string imgUrl { get; set; }
        public int cat_id { get; set; }
        public string cat_name { get; set; }
    }
}