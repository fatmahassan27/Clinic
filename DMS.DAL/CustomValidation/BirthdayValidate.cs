using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMS.DAL.CustomValidation
{
    public class BirthdayValidate :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("Date is required.");
            }
            if (DateTime.TryParse(value.ToString(), out DateTime dateTime))
            {
                if (dateTime.Date > DateTime.Now.Date)
                {
                    return new ValidationResult("The date cannot be in the future.");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date format.");
        }
    }
}
