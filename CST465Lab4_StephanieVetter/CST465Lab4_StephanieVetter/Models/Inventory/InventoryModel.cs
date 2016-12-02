using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CST465Lab4_StephanieVetter
{
    public class InventoryModel
    {
        [HiddenInput(DisplayValue = false)]

        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductCode { get; set; }

        [Required]
        [StringLength(200)]
        public string ProductName { get; set; }

        [Required]
        public int CategoryID { get; set; }

        public string ProductDescription { get; set; }

        [Required]
        public HttpPostedFileWrapper ProductImage { get; set; }

        [Required]
        public Decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public int Count { get; set; }  //for stickers, count per sheet
        public List<SelectListItem> categories { get; set; }
    }
}