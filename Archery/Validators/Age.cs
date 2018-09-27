using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Archery.Validators
{
    public class Age : ValidationAttribute

    {
        public int MinimumAge { get; set; }
        public int MaximumAge { get; set; }

        public Age(int minimumAge)
        {
            this.MinimumAge = minimumAge;//this non obligatoire
        }

        public Age(int minimumAge, int maximumAge)
        {
            this.MinimumAge = minimumAge;//this non obligatoire
            this.MaximumAge = maximumAge;//this non obligatoire
        }

        public override bool IsValid(object value)
        {

            if (value != null)
            {


                if (value is DateTime)
                {

                    if ((this.MaximumAge) != 0)
                        return ((DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value) && (DateTime.Now.AddYears(-this.MaximumAge) <= (DateTime)value));
                    else
                        return DateTime.Now.AddYears(-this.MinimumAge) >= (DateTime)value;
                }
                else
                    throw new ArgumentException("Le type doit etre un DateTime");
            }
            return false;

        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(this.ErrorMessage, name, this.MinimumAge.ToString(), this.MaximumAge.ToString());
        }
    }
}