using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required]
        override public string Answer { get; set; }
    }
}