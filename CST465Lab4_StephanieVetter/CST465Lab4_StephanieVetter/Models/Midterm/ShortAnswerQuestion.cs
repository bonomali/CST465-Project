using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class ShortAnswerQuestion : TestQuestion
    {
        public ShortAnswerQuestion(QuestionData quest)
        {
            this.ID = quest.ID;
            this.Question = quest.Question;
        }
        [Required(ErrorMessage ="Answer Required")]
        [StringLength(100, ErrorMessage = "Max characters: 100")]
        override public string Answer { get; set; }
    }
}