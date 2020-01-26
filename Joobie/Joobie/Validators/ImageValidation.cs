using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace Joobie.Validators
{
    public class ImageValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file == null)
            {
                return ValidationResult.Success;
            }
            try
            {
                string fileExtension = Path.GetExtension(file.FileName);
                if (string.Equals(fileExtension, ".jpg", StringComparison.OrdinalIgnoreCase))
                    return ValidationResult.Success;
                else if (string.Equals(fileExtension, ".png", StringComparison.OrdinalIgnoreCase))
                    return ValidationResult.Success;
            }
            catch { }
            return new ValidationResult("Zły format ikony.Ikona musi mieć format jpg lub img.");
        }
    }
}
