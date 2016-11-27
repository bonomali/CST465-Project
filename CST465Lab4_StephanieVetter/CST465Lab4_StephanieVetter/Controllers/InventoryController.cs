using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST465Lab4_StephanieVetter.Code.Repositories;
using System.IO;

namespace CST465Lab4_StephanieVetter.Controllers
{
    public class InventoryController : Controller
    {
        private InventoryRepository _repo;

        public InventoryController()
        {
            _repo = new InventoryRepository();
        }
        // GET: Inventory
        public ActionResult Index()
        {
            List<Inventory> inventory = _repo.GetList();
            return View(inventory);
        }
  //      [Authorize]
        public ActionResult Add()
        {
            InventoryModel inv = new InventoryModel();

            return View(inv);
        }
        
        [HttpPost]
        public ActionResult Add(InventoryModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ProductImage != null && model.ProductImage.ContentLength < 5000)
            {
                Inventory inv = new Inventory();
                byte[] imageBytes;

                using (var memoryStream = new MemoryStream())
                {
                    model.ProductImage.InputStream.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
                inv.ID = model.ID;
                inv.ProductName = model.ProductName;
                inv.ProductCode = model.ProductCode;
                inv.CategoryID = model.CategoryID;
                inv.ProductImage = imageBytes;
                inv.ProductDescription = model.ProductDescription;
                inv.Money = model.Money;
                inv.Quantity = model.Quantity;
               
                _repo.Save(inv);
            }
           
            return RedirectToAction("Index");
        }

  //      [Authorize]
        public ActionResult Edit(int id)
        {
            Inventory inv = new Inventory();
            inv = _repo.Get(id);

            InventoryModel model = new InventoryModel();
           
            model.ProductImage = inv.ProductImage;
            model.ID = inv.ID;
            model.ProductName = inv.ProductName;
            model.ProductCode = inv.ProductCode;
            model.CategoryID = inv.CategoryID;
            model.ProductDescription = inv.ProductDescription;
            model.Money = inv.Money;
            model.Quantity = inv.Quantity;

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(InventoryModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.ProductImage != null && model.ProductImage.ContentLength < 5000)
            {
                Inventory inv = new Inventory();
                byte[] imageBytes;

                using (var memoryStream = new MemoryStream())
                {
                    model.ProductImage.InputStream.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }
                inv.ID = model.ID;
                inv.ProductName = model.ProductName;
                inv.ProductCode = model.ProductCode;
                inv.CategoryID = model.CategoryID;
                inv.ProductImage = imageBytes;
                inv.ProductDescription = model.ProductDescription;
                inv.Money = model.Money;
                inv.Quantity = model.Quantity;

                _repo.Save(inv);
            }

            return RedirectToAction("Index");
        }
  //      [Authorize]
        public ActionResult Delete()
        {
            return View();
        }
    }
}