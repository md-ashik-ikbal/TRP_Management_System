using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TRP_Management_System.Validation
{
    public class CheckYear : ValidationAttribute
    {
        public int _minYear;
        public CheckYear(int minYear)
        {
            _minYear = minYear;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null && int.TryParse(value.ToString(), out int year))
            {
                int currentYear = DateTime.Now.Year;

                if (year < _minYear || year > currentYear)
                {
                    return new ValidationResult($"The year must be between {_minYear} and {currentYear}.");
                }
            }
            else
            {
                return new ValidationResult("Invalid year format.");
            }

            return ValidationResult.Success;
        }
    }
}