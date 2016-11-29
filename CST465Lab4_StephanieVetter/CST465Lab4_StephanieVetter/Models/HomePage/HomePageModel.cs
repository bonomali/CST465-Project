using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class HomePageModel
    {
        public List<Inventory> inventory { get; set; }
        public List<BlogPost> blogs { get; set; }
    }
}