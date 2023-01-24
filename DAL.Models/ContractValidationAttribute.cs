using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DAL.Models
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class ContractValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            try
            {
                if ((bool)value)
                    return ValidationResult.Success;
                return new ValidationResult("Aydınlatma ve Rıza Metni ile Referans Taahhüdünü onaylamanız gerekmektedir!");
            }
            catch
            {
                return new ValidationResult("Aydınlatma ve Rıza Metni ile Referans Taahhüdünü onaylamanız gerekmektedir! Hatalı işlem!");
            }

        }
    }
}