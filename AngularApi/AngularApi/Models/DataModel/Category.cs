using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularApi.Models.DataModel
{
    public class Category
    {
        [Required][Key]
        public int CategoryId { get; set; }
        [Required][StringLength(255)]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> products { get; set; }
    }
}