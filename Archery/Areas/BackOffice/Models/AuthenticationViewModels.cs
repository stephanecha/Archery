using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Areas.BackOffice.Models
{
    public class AuthenticationLoginViewModel


    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        public int MyProperty { get; set; }
    }
}