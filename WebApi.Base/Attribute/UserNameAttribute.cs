using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi.Base.Attribute
{
    public class UserNameAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if (value is null)
                    return new ValidationResult("Invalid User name field.");

                if (Regex.IsMatch(value.ToString(), @"\s", RegexOptions.Compiled))
                    return new ValidationResult("User name is not contain any space characters.");

                return ValidationResult.Success;
            }
            catch
            {
                return new ValidationResult("Invalid User name field.");
            }
        }
    }
}
