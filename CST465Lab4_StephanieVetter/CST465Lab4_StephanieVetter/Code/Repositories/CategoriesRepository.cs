using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter.Code.Repositories
{
    public class CategoriesRepository : IDataEntityRepository<Category>
    {
        public Category Get(int id)
        {
            Category category = new Category();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Category WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            category.ID = (int)reader["ID"];
                            category.CategoryName = reader["CategoryName"].ToString();
                        }
                    }
                }
            }
            return category;
        }

        public List<Category> GetList()
        {
            List<Category> categories = new List<Category>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Category";
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category category = new Category();

                            category.ID = (int)reader["ID"];
                            category.CategoryName = reader["CategoryName"].ToString();

                            categories.Add(category);
                        }
                    }
                }
            }
            return categories;
        }

        public void Save(Category entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Category(CategoryName) VALUES(@Name)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Category SET CategoryName=@Name WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Name", entity.CategoryName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}