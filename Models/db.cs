﻿using System.Data;
using System.Data.SqlClient;

namespace Assignment2.Models
{
    public class db
    {
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assignment2.Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        public SqlConnection Con { get => con; set => con = value; }

        public int LoginCheck(Login ad)
        {
            var com = new SqlCommand("Sp_Login", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@user_id", ad.user_id);
            com.Parameters.AddWithValue("@Password", ad.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            Con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            Con.Close();
            return res;
        }
    }
}
