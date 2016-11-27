using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST465Lab4_StephanieVetter.Code.Repositories;

namespace CST465Lab4_StephanieVetter.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesRepository _repo; 
        
        public CategoriesController()
        {
            _repo = new CategoriesRepository();
        }        

        // GET: Categories
        public ActionResult Index()
        {
            List<Category> categories = _repo.GetList();

            return View(categories);
        }

 //     [Authorize]
        public ActionResult Insert()
        {
            CategoriesModel cat = new CategoriesModel();

            return View(cat);
        }

        [HttpPost]
        public ActionResult Insert(CategoriesModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            Category cat = new Category();

            cat.ID = model.ID;
            cat.CategoryName = model.CategoryName;

            _repo.Save(cat);

            return RedirectToAction("Index");
        }
 //       [Authorize]
        public ActionResult Edit(int id)
        {
            Category cat = new Category();
            cat = _repo.Get(id);

            CategoriesModel model = new CategoriesModel();

            model.ID = cat.ID;
            model.CategoryName = cat.CategoryName;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoriesModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Category cat = new Category();

            cat.ID = model.ID;
            cat.CategoryName = model.CategoryName;

            _repo.Save(cat);

            return RedirectToAction("Index");
        }

  //      [Authorize]
        public ActionResult Delete(int id)
        {
            Category cat = new Category();
            int count = 0;
            cat = _repo.Get(id);
            count = _repo.Delete(cat);
            if(count.Equals(1))
                return View("Delete");

            return RedirectToAction("Index");
        }
    }
}