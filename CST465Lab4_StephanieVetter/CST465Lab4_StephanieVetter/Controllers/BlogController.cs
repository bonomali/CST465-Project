using CST465Lab4_StephanieVetter.Code.Repositories;
using CST465Lab4_StephanieVetter.Code.ExtensionMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class BlogController : Controller
    {
        private IDataEntityRepository<BlogPost> _blog;

        public BlogController(IDataEntityRepository<BlogPost> repo)
        {
            //_blog = new BlogDBRepository();
            _blog = repo;
        }
        // GET: Blog
        public ActionResult Index()
        {
            List<BlogPost> b = _blog.GetList();

            return View(b);
        }

        [HttpPost]
        public ActionResult Index(string filter)
        {
            List<BlogPost> b = _blog.GetListByContent(filter);

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

                _blog.Save(b);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
        [Authorize]
        public ActionResult Edit(int id)
        {
            BlogPost b = new BlogPost();
            b = _blog.Get(id);

            BlogPostModel model = new BlogPostModel();
            model.ID = b.ID;
            model.Title = b.Title;
            model.Content = b.Content;
            model.Author = b.Author;
            
            return View(model);
        }
        [Authorize]
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

                _blog.Save(b);
            }
            else
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }

        public ActionResult SingleBlogPostView(int id)
        { 
            BlogPost b = new BlogPost();
            b = _blog.Get(id);

            return View(b);
        }
    }
}