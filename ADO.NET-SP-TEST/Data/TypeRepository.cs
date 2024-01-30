using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using SDSolutionsExam.Models;
using System.Data;
using System.Web.Mvc;

namespace SDSolutionsExam.Data
{
    public class TypeRepository
    {
        private SqlConnection connection;

        public TypeRepository()
        {
            string connectionString = "server=DESKTOP-QLHIHI2;database=recycableDb;" +
                "integrated security=true;TrustServerCertificate=true";

            connection = new SqlConnection(connectionString);

        }

        public List<TypeEntity> getAllTypes()
        {
            List<TypeEntity> typeListEntity = new List<TypeEntity>();

            SqlCommand cmd = new SqlCommand("getAllType", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            foreach(DataRow dataRow in dataTable.Rows)
            {
                typeListEntity.Add(
                    new TypeEntity
                    {
                        Id = Convert.ToInt32(dataRow["Id"]),
                        Type = Convert.ToString(dataRow["Type"]),
                        Rate = Convert.ToDecimal(dataRow["Rate"]),
                        MinKg = Convert.ToDecimal(dataRow["MinKg"]),
                        MaxKg = Convert.ToDecimal(dataRow["MaxKg"])
                    }

                    );
            }

            return typeListEntity;
        }

        public TypeEntity getTypeById(int Id)
        {
            TypeEntity typeListEntity = new TypeEntity();

            SqlCommand cmd = new SqlCommand("getTypeById", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter param;

            cmd.Parameters.Add(new SqlParameter("@Id", Id));

            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);

            DataTable dataTable = new DataTable();

            dataAdapter.Fill(dataTable);

            foreach (DataRow dataRow in dataTable.Rows)
            {
                typeListEntity = new TypeEntity
                    {
                        Id = Convert.ToInt32(dataRow["Id"]),
                        Type = Convert.ToString(dataRow["Type"]),
                        Rate = Convert.ToDecimal(dataRow["Rate"]),
                        MinKg = Convert.ToDecimal(dataRow["MinKg"]),
                        MaxKg = Convert.ToDecimal(dataRow["MaxKg"])

                    };
            }

            return typeListEntity;
        }

        public bool AddType(TypeEntity type)
        {
            SqlCommand cmd = new SqlCommand("AddType", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Type", type.Type);
            cmd.Parameters.AddWithValue("@Rate", type.Rate);
            cmd.Parameters.AddWithValue("@MinKg", type.MinKg);
            cmd.Parameters.AddWithValue("@MaxKg", type.MaxKg);

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

        public bool EditTypeDetails(int Id, TypeEntity type)
        {
            SqlCommand cmd = new SqlCommand("EditType", connection);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Id", Id);
            cmd.Parameters.AddWithValue("@Type", type.Type);
            cmd.Parameters.AddWithValue("@Rate", type.Rate);
            cmd.Parameters.AddWithValue("@MinKg", type.MinKg);
            cmd.Parameters.AddWithValue("@MaxKg", type.MaxKg);

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

        public bool DeleteTypeDetails(int Id, TypeEntity type)
        {
            SqlCommand cmd = new SqlCommand("DeleteTypeDetails", connection);
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