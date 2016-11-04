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
            string json = System.IO.File.ReadAllText(@"C:\Users\Stephanie\Documents\GitHub\CST465-Project\CST465Lab4_StephanieVetter\CST465Lab4_StephanieVetter\JSON\Midterm.json");
            questions = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<TestQuestion>>(json);

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
            List<TestQuestion> q = GetQuestions();

            return View(q);
        }

        [HttpPost]
        public ActionResult TakeTest(List<TestQuestion> model)
        {
            test = GetQuestions();

            for (int i = 0; i < model.Count; i++)
            {
                if (!ModelState.IsValid)
                {
                    return View(model);
                }
            }

            for (int i = 0; i < test.Count || i < model.Count; i++)
            {
             
                if (test[i].ID == model[i].ID)
                    model[i].Answer = test[i].Answer;
            }

            TempData["TestData"] = model;

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