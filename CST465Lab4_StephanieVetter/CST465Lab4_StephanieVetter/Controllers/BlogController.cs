using CST465Lab4_StephanieVetter.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter.Controllers
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> blog;

        public BlogController()
        {
            blog = new BlogDBRepository();
        }
        // GET: Blog
        public ActionResult Index()
        {
            List<BlogPost> b = blog.GetList();

            return View(b);
        }
        public ActionResult Add()
        {
            BlogPostModel model = new BlogPostModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Add(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost b = new BlogPost();

                b.ID = model.ID;
                b.Title = model.Title;
                b.Content = model.Content;
                b.Author = model.Author;

                blog.Save(b);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            BlogPost b = new BlogPost();
            b = blog.Get(id);

            BlogPostModel model = new BlogPostModel();
            model.ID = b.ID;
            model.Title = b.Title;
            model.Content = b.Content;
            model.Author = b.Author;
            
            return View(model);
        }

        [HttpPost]
         public ActionResult Edit(BlogPostModel model)
        {
            if(ModelState.IsValid)
            {
                BlogPost b = new BlogPost();

                b.ID = model.ID;
                b.Title = model.Title;
                b.Content = model.Content;
                b.Author = model.Author;

                blog.Save(b);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

    }
}