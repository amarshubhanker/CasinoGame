using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Casino.Web.Models.CustomValidatons
{
    public class AgeValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime dtV = (DateTime)value;
            long lTicks = DateTime.Now.Ticks - dtV.Ticks;
            DateTime dtAge = new DateTime(lTicks);
            string ErrorMessage = "Age must be greater than 18";

            if (dtAge.Year < 18)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }

    }
}