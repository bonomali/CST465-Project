using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class Inventory : IDataEntity
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }
        public Decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}