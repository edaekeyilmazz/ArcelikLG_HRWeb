using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcelikLgHRWeb
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class TCKimlikNoValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string)
            {
                string val = (string)value;
                if (TCNoControl(val))
                    return ValidationResult.Success;
                return new ValidationResult("Lütfen geçerli bir TC. kimlik numarası giriniz!");
            }
            else
                return new ValidationResult("TCKimlikNo validation attribute only use for string types!");
        }

        private bool TCNoControl(string TCNo)
        {
            try
            {
                if (string.IsNullOrEmpty(TCNo) || TCNo.Length != 11)
                    return false;
                int[] TC = new int[11];
                for (int i = 0; i < 11; i++)
                    TC[i] = (int)char.GetNumericValue(TCNo[i]);

                int odds = 0;
                int evens = 0;

                for (int k = 0; k < 9; k++)
                {
                    if (k % 2 == 0)
                        odds += TC[k];
                    else if (k % 2 != 0)
                        evens += TC[k];
                }

                int t1 = (odds * 3) + evens;
                int c1 = (10 - (t1 % 10)) % 10;
                int t2 = c1 + evens;
                int t3 = (t2 * 3) + odds;
                int c2 = (10 - (t3 % 10)) % 10;

                if (c1 == TC[9] && c2 == TC[10])
                    return true;
                else
                    return false;

            }
            catch
            {
                return false;
            }
        }
    }
}
