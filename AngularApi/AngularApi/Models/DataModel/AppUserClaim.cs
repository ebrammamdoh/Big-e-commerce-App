using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AngularApi.Models.DataModel
{
    [Table("UserClaim",Schema ="Security")]
    public class AppUserClaim
    {
        [Required][Key]
        public int ClaimId { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public string ClaimType { get; set; }
        [Required]
        public string ClaimValue { get; set; }
    }
}