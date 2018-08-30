using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularApi.Models.DataModel
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required][StringLength(255)]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        public Nullable<decimal> Price { get; set; }
        public Nullable<int> Quentity { get; set; }
        public Nullable<decimal> Rate { get; set; }
        public string ImgUrl { get; set; }
        public virtual Category category { get; set; } 
    }
}