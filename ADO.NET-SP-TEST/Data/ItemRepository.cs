using SDSolutionsExam.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace SDSolutionsExam.Data
{
    public class ItemRepository
    {
        private SqlConnection connection;

        public ItemRepository()
        {
            string connectionString = "server=DESKTOP-QLHIHI2;database=recycableDb;" +
                "integrated security=true;TrustServerCertificate=true";

            connection = new SqlConnection(connectionString);


        }


        public List<int> GetRecycableTypeIds()
        {
            List<int> recycableTypeIds = new List<int>();

            SqlCommand cmd = new SqlCommand("SELECT Id FROM RecycableTypeTable", connection);
            connection.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    recycableTypeIds.Add(reader.GetInt32(0));
                }
            }

            connection.Close();

            return recycableTypeIds;
        }


        public List<ItemEntity> getAllItems()
        {
            List<ItemEntity> itemListEntity = new List<ItemEntity>();

            SqlCommand cmd = new SqlCommand("getAllItem", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                itemListEntity.Add(
                    new ItemEntity
                    {
                        Id = Convert.ToInt32(dataRow["Id"]),
                        RecycableTypeId = Convert.ToInt32(dataRow["RecycableTypeId"]),
                        Weight = Convert.ToDecimal(dataRow["Weight"]),
                        ComputedWeight = Convert.ToDecimal(dataRow["ComputedWeight"]),
                        ItemDescription = Convert.ToString(dataRow["ItemDescription"])
                    }

                    );
            }

            return itemListEntity;
        }

        public ItemEntity getItemById(int Id)
        {
            ItemEntity itemListEntity = new ItemEntity();

            SqlCommand cmd = new SqlCommand("getItemById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param;

            cmd.Parameters.Add(new SqlParameter("@Id", Id));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                itemListEntity = new ItemEntity
                {
                    Id = Convert.ToInt32(dataRow["Id"]),
                    RecycableTypeId = Convert.ToInt32(dataRow["RecycableTypeId"]),
                    Weight = Convert.ToDecimal(dataRow["Weight"]),
                    ComputedWeight = Convert.ToDecimal(dataRow["ComputedWeight"]),
                    ItemDescription = Convert.ToString(dataRow["ItemDescription"])
                };
            }

            return itemListEntity;
        }


        public bool AddItem(ItemEntity item)
        {
            SqlCommand cmd = new SqlCommand("AddItem", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@RecycableTypeId", item.RecycableTypeId);
            cmd.Parameters.AddWithValue("@Weight", item.Weight);
            cmd.Parameters.AddWithValue("@ComputedWeight", item.ComputedWeight);
            cmd.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);

            connection.Open();

            int i = cmd.ExecuteNonQuery();

            connection.Close();

            if (i >= 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool EditItemDetails(int Id, ItemEntity item)
        {
            SqlCommand cmd = new SqlCommand("EditItem", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@RecycableTypeId", item.RecycableTypeId);
            cmd.Parameters.AddWithValue("@Weight", item.Weight);
            cmd.Parameters.AddWithValue("@ComputedWeight", item.ComputedWeight);
            cmd.Parameters.AddWithValue("@ItemDescription", item.ItemDescription);

            connection.Open();

            int i = cmd.ExecuteNonQuery();

            connection.Close();

            if (i >= 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public bool DeleteItemDetails(int Id, ItemEntity item)
        {
            SqlCommand cmd = new SqlCommand("DeleteItemDetails", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);

            connection.Open();

            int i = cmd.ExecuteNonQuery();

            connection.Close();

            if (i >= 1)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}