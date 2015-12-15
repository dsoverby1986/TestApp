using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestApp.Models
{
    public class MessageBook : IValidatableObject
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DisplayName("Date of Birth")]
        public DateTime Dob { get; set; }
        [Required]
        [DataType(DataType.MultilineText)]
        public string Message { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Dob > DateTime.Now)
            {
                yield return new ValidationResult("Date of Birth can't be in future.");
            }

            if(Dob < DateTime.Now.AddYears(-100))
            {
                yield return new ValidationResult("Date of Birth can't be in too past.");
            }
        }
    }
}