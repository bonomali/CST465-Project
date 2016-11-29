using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"(\(\d{3}\)|\d{3}\-)\d{3}\-\d{4}", ErrorMessage = "Phone Number Format: (000)000-0000")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Message { get; set; }
    }
}