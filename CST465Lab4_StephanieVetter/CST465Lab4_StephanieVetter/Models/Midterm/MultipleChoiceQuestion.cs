using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class MultipleChoiceQuestion : TestQuestion
    {
        [Required]
        override public string Answer { get; set; }

        public List<SelectListItem> items = new List<SelectListItem>()
        {
            (new SelectListItem { Text = "True", Value = "True" }),
            (new SelectListItem { Text = "False", Value = "False" })
        };
    }


}