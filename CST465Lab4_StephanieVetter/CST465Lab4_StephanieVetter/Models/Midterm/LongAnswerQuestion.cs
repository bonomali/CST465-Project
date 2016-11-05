using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class LongAnswerQuestion : TestQuestion
    {
        public LongAnswerQuestion(QuestionData quest)
        {
            this.ID = quest.ID;
            this.Question = quest.Question;
            this.Choices = quest.Choices;
        }
        [Required(ErrorMessage = "Answer Required")]
        override public string Answer { get; set; }
    }
}