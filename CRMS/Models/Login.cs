using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRMS.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Username required", AllowEmptyStrings = false)]
        public String Username { get; set; }
        [Required(ErrorMessage = "Password required", AllowEmptyStrings = false)]
        [DataType(System.ComponentModel.DataAnnotations.DataType.Password)]
        public String Password { get; set; }
        public bool RememberMe { get; set; }
    }
}