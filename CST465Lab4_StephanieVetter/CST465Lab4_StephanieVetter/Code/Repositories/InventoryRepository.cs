using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CST465Lab4_StephanieVetter.Code.Repositories
{
    public class InventoryRepository : IDataEntityRepository<Inventory>
    {
        public Inventory Get(int id)
        {
            Inventory item = new Inventory();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Product WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item.ID = (int)reader["ID"];
                            item.ProductCode = reader["ProductCode"].ToString();
                            item.ProductName = reader["ProductName"].ToString();
                            item.CategoryID = (int)reader["CategoryID"];
                            item.ProductDescription = reader["ProductDescription"].ToString();
                            item.ProductImage = (byte[])reader["ProductImage"];
                            item.Money = (float)reader["Money"];
                            item.Quantity = (int)reader["Quanity"];
                        }
                    }
                }
            }
            return item;
        }

        public List<Inventory> GetList()
        {
            List<Inventory> inventory = new List<Inventory>();

            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Product";
                    command.Connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inventory item = new Inventory();

                            item.ID = (int)reader["ID"];
                            item.ProductCode = reader["ProductCode"].ToString();
                            item.ProductName = reader["ProductName"].ToString();
                            item.CategoryID = (int)reader["CategoryID"];
                            item.ProductDescription = reader["ProductDescription"].ToString();
                            item.ProductImage = (byte[])reader["ProductImage"];
                            item.Money = (float)reader["Money"];
                            item.Quantity = (int)reader["Quanity"];

                            inventory.Add(item);
                        }
                    }
                }
            }
            return inventory;
        }

        public void Save(Inventory entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Product(ProductCode, ProductName, CategoryID, ProductDescription, ProductImage, Money, Quantity) VALUES(@Code, @PName, @CID, @Description, @Image, @Money, @Quantity)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Product SET ProductCode=@Code, ProductName=@PName, CategoryID=@CID, ProductDescription=@Description, ProductImage=@Image, Money=@Money, Quantity=@Quantity WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.CommandType = CommandType.Text;
                    command.Parameters.AddWithValue("@Code", entity.ProductCode);
                    command.Parameters.AddWithValue("@PName", entity.ProductName);
                    command.Parameters.AddWithValue("@CID", entity.CategoryID);
                    command.Parameters.AddWithValue("@Description", entity.ProductDescription);
                    command.Parameters.AddWithValue("@Image", entity.ProductImage);
                    command.Parameters.AddWithValue("@Money", entity.Money);
                    command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}