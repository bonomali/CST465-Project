using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class MidtermController : Controller
    {
        List<TestQuestion> questions = new List<TestQuestion>();
        List<TestQuestion> test = new List<TestQuestion>();

        public List<TestQuestion> GetQuestions()
        {
            List<QuestionData> temp = new List<QuestionData>();
            string json = System.IO.File.ReadAllText(Server.MapPath("/JSON/Midterm.json"));
            temp = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<QuestionData>>(json);

            for(int i = 0; i < temp.Count; i++)
            {
                if (temp[i].Type.Equals("TrueFalseQuestion"))
                    questions.Add(new TrueFalseQuestion(temp[i]));
                else if(temp[i].Type.Equals("LongAnswerQuestion"))
                        questions.Add(new LongAnswerQuestion(temp[i]));
                else if (temp[i].Type.Equals("ShortAnswerQuestion"))
                    questions.Add(new ShortAnswerQuestion(temp[i]));
                else if (temp[i].Type.Equals("MultipleChoiceQuestion"))
                    questions.Add(new MultipleChoiceQuestion(temp[i]));
            }

            return questions;
        }
        // GET: Midterm
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult TakeTest()
        {
            GetQuestions();

            return View(questions);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult TakeTest(List<TestQuestion> model)
        {
            test = GetQuestions();

            if (!ModelState.IsValid)
            {
                return RedirectToAction("TakeTest");
            }

            for (int i = 0; i < test.Count || i < model.Count; i++)
            {
             
                if (test[i].ID == model[i].ID)
                    test[i].Answer = model[i].Answer;
            }
            TempData["TestData"] = test;
        
            return RedirectToAction("DisplayResults");
        }

        [HttpGet]
        public ActionResult DisplayResults()
        {
            List<TestQuestion> q = new List<TestQuestion>();

            if (TempData["TestData"] != null)
            {
                q = TempData["TestData"] as List<TestQuestion>;
            }
            return View(q);
        } 
    }
}