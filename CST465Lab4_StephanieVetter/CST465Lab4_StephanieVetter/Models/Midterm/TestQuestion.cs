using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CST465Lab4_StephanieVetter
{
    public class TestQuestion
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public virtual string Answer { get; set; }
        public List<string> Choices { get; set; }
    }

    public class QuestionData
    {
        public int ID { get; set; }
        public string Question { get; set; }
        public string Type { get; set; }
        public List<string> Choices { get; set; }
    }

}
