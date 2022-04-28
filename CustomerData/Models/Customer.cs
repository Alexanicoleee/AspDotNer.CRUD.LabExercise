using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CustomerData.Models
{
    public class Customer : BaseEntity
    {
        [Required]
        [MinLength(4, 
            ErrorMessage = "The field First Name must be a string with a minimum length of '4'")]
        [MaxLength(17)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(4, ErrorMessage = "The field First Name must be a string with a minimum length of '4'")]
        [MaxLength(17)]
        public string LastName { get; set; }


        public string? Address { get; set; }

        [Phone]
        [CheckValidPhone]
        public string? Phone { get; set; }

    }
    public class CheckValidPhone : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                Regex r = new Regex("^\\d{11}$");
                bool validPhoneChecker = r.IsMatch((string)value);
                if (validPhoneChecker || value == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return true;
            }

        }
        public CheckValidPhone()
        {
            ErrorMessage = "Phone Number pattern doesn't match. Phone Number consist of 11 numbers";
        }
    }



}
