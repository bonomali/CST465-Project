﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CST465Lab4_StephanieVetter.Code.Repositories;
using CST465Lab4_StephanieVetter.Code.ExtensionMethods;
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
        [HttpPost]
        public ActionResult Index(string filter)
        {
            List<Inventory> i = _repo.GetListByName(filter);

            return View(i);
        }
        [HttpPost]
        public ActionResult Index2(string filter)
        {
            CategoriesRepository repo = new CategoriesRepository();
            List<Category> cat = repo.GetList();
            Category c = new Category();
            bool found = false;

            for (int j = 0; j < cat.Count() && found == false; j++)
            {
                if (cat[j].CategoryName.ToUpper() == filter.ToUpper())
                {
                    c = cat[j];
                    found = true;
                }
            }
            List<Inventory> i = _repo.GetListByCategory(c);
            return View(i);
        }
        public ActionResult Show(int id)
        {
            Inventory image = _repo.Get(id);

            return File(image.ProductImage, image.ProductName);
        }

        [Authorize]
        public ActionResult ViewItem(int id)
        {
            Inventory inv = new Inventory();
            inv = _repo.Get(id);

            return View(inv);
        }

        [Authorize]
        public ActionResult Add()
        {
            InventoryModel inv = new InventoryModel();

            List<Category> temp = new List<Category>();
            CategoriesRepository repo = new CategoriesRepository();
            temp = repo.GetList();

            if (temp.Count() > 0)
            {
                inv.categories = new List<SelectListItem>();
                foreach(Category c in temp)
                {
                    inv.categories.Add(new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() });
                }
                return View(inv);
            }
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(InventoryModel model)
        {
            List<Category> temp = new List<Category>();
            CategoriesRepository repo = new CategoriesRepository();
            temp = repo.GetList();

            model.categories = new List<SelectListItem>();
            foreach (Category c in temp)
            {
                model.categories.Add(new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() });
            }
            if (!ModelState.IsValid || model.ProductImage == null)
            {
                return View(model);
            }

            if (model.ProductImage != null && model.ProductImage.ContentLength < 50000)
            {
                Inventory inv = new Inventory();
                byte[] imageBytes;

                using (var memoryStream = new MemoryStream())
                {
                    model.ProductImage.InputStream.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                }

                inv.ProductImage = imageBytes;
                inv.ID = model.ID;
                inv.ProductName = model.ProductName;
                inv.ProductCode = model.ProductCode;
                inv.CategoryID = model.CategoryID;
                inv.ProductDescription = model.ProductDescription;
                inv.Price = model.Price;
                inv.Quantity = model.Quantity;

                if (model.ProductDescription == null)
                    inv.ProductDescription = "";
                else
                    inv.ProductDescription = model.ProductDescription;

                _repo.Save(inv);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            Inventory inv = new Inventory();
            inv = _repo.Get(id);

            InventoryModel model = new InventoryModel();
            Stream stream = new MemoryStream(inv.ProductImage);
            //HttpPostedFileWrapper file = new HttpPostedFileWrapper(stream);
            //model.ProductImage = stream;
            model.ID = inv.ID;
            model.ProductName = inv.ProductName;
            model.ProductCode = inv.ProductCode;
            model.CategoryID = inv.CategoryID;
            model.ProductDescription = inv.ProductDescription;
            model.Price = inv.Price;
            model.Quantity = inv.Quantity;
            
            List<Category> temp = new List<Category>();
            CategoriesRepository repo = new CategoriesRepository();
            temp = repo.GetList();

            model.categories = new List<SelectListItem>();
            foreach (Category c in temp)
            {
                model.categories.Add(new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() });
            }
            return View(model);
           
        }

        [HttpPost]
        public ActionResult Edit(InventoryModel model)
        {
            List<Category> temp = new List<Category>();
            CategoriesRepository repo = new CategoriesRepository();
            temp = repo.GetList();

            model.categories = new List<SelectListItem>();
            foreach (Category c in temp)
            {
                model.categories.Add(new SelectListItem { Text = c.CategoryName, Value = c.ID.ToString() });
            }
            if (!ModelState.IsValid || model.ProductImage.ContentLength < 1)
            {
                return View(model);
            }

            if (model.ProductImage != null && model.ProductImage.ContentLength < 50000)
            {
                Inventory inv = new Inventory();

                byte[] imageBytes;

                using (var memoryStream = new MemoryStream())
                {
                    model.ProductImage.InputStream.CopyTo(memoryStream);
                    imageBytes = memoryStream.ToArray();
                 }

                inv.ProductImage = imageBytes;
                inv.ID = model.ID;
                inv.ProductName = model.ProductName;
                inv.ProductCode = model.ProductCode;
                inv.CategoryID = model.CategoryID;
                inv.ProductDescription = model.ProductDescription;
                inv.Price = model.Price;
                inv.Quantity = model.Quantity;

                if (model.ProductDescription == null)
                    inv.ProductDescription = "";
                else
                    inv.ProductDescription = model.ProductDescription;

                _repo.Save(inv);
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        public ActionResult Delete(int id)
        {
            Inventory inv = new Inventory();
            inv = _repo.Get(id);
            _repo.Delete(inv);

            return RedirectToAction("Index");
        }
    }
}