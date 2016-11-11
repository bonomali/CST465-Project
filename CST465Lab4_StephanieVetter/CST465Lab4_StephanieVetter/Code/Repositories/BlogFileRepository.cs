using Microsoft.ApplicationInsights.Extensibility.Implementation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CST465Lab4_StephanieVetter.Code.Repositories
{
    public class BlogFileRepository : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            List<BlogPost> blogs = GetList();
            BlogPost b = new BlogPost();

            foreach(BlogPost blog in blogs)
            {
                if (blog.ID.Equals(id))
                    b = blog;
            }

            return b;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> blogs = new List<BlogPost>();
            string json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/App_Data/blogLab7.json"));

            using (StreamReader file = new StreamReader(HttpContext.Current.Server.MapPath("/App_Data/blogLab7.json")))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                blogs = (List<BlogPost>)serializer.Deserialize(file.ReadToEnd(), typeof(List<BlogPost>));
                file.Close();
            } 
            
            return blogs;
        }

        public void Save(BlogPost entity)
        {
            List<BlogPost> blogs = GetList();
            if (entity.ID == 0)
            {
                entity.ID = blogs.Count + 1;
                entity.Timestamp = DateTime.Now.ToLocalTime();
                blogs.Add(entity);
            }
            else
            {
                BlogPost blog = blogs.Where(b => b.ID == entity.ID).FirstOrDefault();
                blog.ID = entity.ID;
                blog.Title = entity.Title;
                blog.Author = entity.Author;
                blog.Content = entity.Content;
                blog.Timestamp = entity.Timestamp;                
            }

            using (StreamWriter file = new StreamWriter(HttpContext.Current.Server.MapPath("/App_Data/blogLab7.json")))
            {
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string json = serializer.Serialize(blogs);
                file.Write(json);
                file.Close();
            }
        }
    }
}