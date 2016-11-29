using CST465Lab4_StephanieVetter.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class HomeController : Controller
    {
        IDataEntityRepository<BlogPost> _brepo;
        IDataEntityRepository<Inventory> _irepo;

        public HomeController()
        {
            _brepo = new BlogDBRepository();
            _irepo = new InventoryRepository();
        }
        // GET: Home
        public ActionResult Index()
        {
            List<Inventory> inv = new List<Inventory>();
            List<Inventory> itemp = _irepo.GetList();
            List<BlogPost> btemp = _brepo.GetList();

            List<BlogPost> SortedList = btemp.OrderByDescending(b => b.ID).ToList();
       
            for (int i = 0; i < 5; i++)
                inv.Add(itemp[i]);

            HomePageModel model = new HomePageModel();
            model.inventory = inv;
            model.blogs = SortedList;

            return View(model);
        }
        public ActionResult Show(int id)
        {
            Inventory image = _irepo.Get(id);

            return File(image.ProductImage, image.ProductName);
        }
    }
}