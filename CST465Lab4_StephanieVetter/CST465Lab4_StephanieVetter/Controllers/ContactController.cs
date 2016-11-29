using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class ContactController : Controller
    {
        // GET: Contact
        public ActionResult Index()
        {
            ContactModel model = new ContactModel();
            
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(ContactModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            return RedirectToAction("ContactConfirmed");
        }
    }
}