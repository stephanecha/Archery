using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Areas.BackOffice.Models
{
    public class AuthenticationLoginViewModel


    {
        [Display(Name = "Login")]
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        public string Mail { get; set; }
        [Display(Name = "Mot de passe")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        public string Password { get; set; }
    }
}