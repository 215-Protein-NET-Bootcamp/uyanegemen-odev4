using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebApi.Base.Attribute
{
    public class PasswordAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                string source = value.ToString();

                // Validate pwd must be MD5 format
                if (!Regex.IsMatch(source, "^[0-9a-fA-F]{32}$", RegexOptions.Compiled))
                    return new ValidationResult("Password must MD5 format.");

                return ValidationResult.Success;
            }
            catch (Exception)
            {
                return new ValidationResult("Password must MD5 format.");
            }
        }
    }
}
