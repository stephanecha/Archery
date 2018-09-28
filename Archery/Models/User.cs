using Archery.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Archery.Models
{
    public abstract class User
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        [StringLength(15, ErrorMessage = "Le champs {0} doit contenir {1} car max")]
        [Display(Name = "Adresse mail")]

        // [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
        //                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
        //                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"
        //     , ErrorMessage = "Le format n'est pas bon.")] 

        [RegularExpression((@"^([\w]+)@([\w]+)\.([\w]+)$"))]
        public string Mail { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        [Display(Name = "Mot de passe")]
       // [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{6,}$", ErrorMessage = "{0} incorrect.")]
        [DataType(DataType.Password)]
        [StringLength(150)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirmation Mot de passe")]
        [NotMapped]
        public string ConfirmedPassword { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        [StringLength(50)]
        [Display(Name = "Nom")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        [Display(Name = "Prenom")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Le champs {0} est mandatory")]
        [Display(Name = "Date naissance")]
        [DataType(DataType.Date)]
        //[Range(9, 100, ErrorMessage = "age mini 9ans")]
        [Age(8, 18, ErrorMessage = "age mini {1}ans age maxi{2}")]
       // [Age(8, ErrorMessage = "age mini {1}ans")]
       [Column(TypeName ="datetime2")]
        public DateTime BirthDate { get; set; }

        // public bool getAge(DateTime birthDate)
        //{
        //    int age;

        //    age = DateTime.Now.Year - birthDate.Year;

        //    if (age > 9)
        //        return true;
        //    else
        //        return false;

        //}
         

        //  [RegularExpression(@"(^[3]{1}[1-9]{1}$)|(^[4-9]{1}[0-9]{1}$)|(^[1-9]{1}[0-9]{2,1000}$)")]     
        // public int getAge
        //{
        //    get
        //    {

        //        return DateTime.Now.Year - BirthDate.Year;

        //    }

        //}
    }
}