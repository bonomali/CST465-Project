using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter
{
    public class BlogPost : IDataEntity
    {
        public int ID { get; set; } 
  
        public String Title { get; set; }
        public String Content { get; set; }
        public String Author { get; set; }

        public DateTime Timestamp { get; set; }
    } 
}