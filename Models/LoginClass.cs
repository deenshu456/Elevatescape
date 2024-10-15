using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Elevatescape.Models
{
    public class LoginClass
    {
        [Required(ErrorMessage="Please enter email id")]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}