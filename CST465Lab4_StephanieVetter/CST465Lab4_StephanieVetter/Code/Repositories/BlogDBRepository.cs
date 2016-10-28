using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter.Code.Repositories
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        
        public BlogPost Get(int id)
        {
            BlogPost post = new BlogPost();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            post.ID = (int)reader["ID"];
                            post.Title = reader["Title"].ToString();
                            post.Content = reader["Content"].ToString();
                            post.Author = reader["Author"].ToString();
                            post.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                        }
                    }
                }
            }
            return post;
        }
        public List<BlogPost> GetList()
        {
            List<BlogPost> blogs = new List<BlogPost>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog";
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPost post = new BlogPost();

                            post.ID = (int)reader["ID"];
                            post.Title = reader["Title"].ToString();
                            post.Content = reader["Content"].ToString();
                            post.Author = reader["Author"].ToString();
                            post.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());

                            blogs.Add(post);
                        }
                    }
                }
            }
            return blogs;
        }
        public void Save(BlogPost entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Blog(Author, Title, Content) VALUES(@Author, @Title, @Content)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Blog SET Author=@Author, Title=@Title, Content=@Content WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Author", entity.Author);
                    command.Parameters.AddWithValue("@Title", entity.Title);
                    command.Parameters.AddWithValue("@Content", entity.Content);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}