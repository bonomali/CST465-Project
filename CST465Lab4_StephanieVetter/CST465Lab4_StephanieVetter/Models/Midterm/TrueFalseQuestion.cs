using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class TrueFalseQuestion : CST465Lab4_StephanieVetter.TestQuestion
    {
        [Required]
        [RegularExpression(@"True + False", ErrorMessage = "Must answer 'True' or 'False'")]
        override public string Answer { get; set; }
    }
    public enum Choices
    {
        True,
        False
    }
}