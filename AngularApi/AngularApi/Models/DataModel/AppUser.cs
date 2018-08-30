using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularApi.Models.DataModel
{
    [Table("User",Schema ="Security")]
    public partial class AppUser
    {
        [Required][Key]
        public int UserId { get; set; }
        [Required][StringLength(255)]
        public string username { get; set; }
        [Required][StringLength(255)]
        public string password { get; set; }
    }
}