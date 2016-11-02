using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class MidtermController : Controller
    {
        public List<TestQuestion> GetQuestions()
        {
            List<TestQuestion> questions = new List<TestQuestion>();

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
            List<TestQuestion> q = new List<TestQuestion>();
            q = GetQuestions();

            return View(q);
        }

        /*       [HttpPost]
               public ActionResult TakeTest()
               {

                   return View();
               }

               [HttpGet]
               public ActionResult DisplayResults()
               {

                   return View();
               }
       */
        public ActionResult SelectCategory()
        {
            List<SelectListItem> items = new List<SelectListItem>();

            items.Add(new SelectListItem { Text = "True", Value = "0" });
            items.Add(new SelectListItem { Text = "False", Value = "1" });

            ViewBag.SelectAnswer = items;

            return View();
        }
    }
}