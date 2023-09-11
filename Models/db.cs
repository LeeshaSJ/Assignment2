using System.Data;
using System.Data.SqlClient;

namespace Assignment2.Models
{
    public class db
    {
        private SqlConnection con = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Assignment2.Data;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

        public SqlConnection Con { get => con; set => con = value; }

        public int LoginCheck(LoginModel ad)
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

        public List<ResourcesModel> GetResources(LoginModel ad)
        {
            var com = new SqlCommand("Sp_GetResources", Con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@user_id", ad.user_id);
            com.Parameters.AddWithValue("@Password", ad.Password);
            Con.Open();
            var reader = com.ExecuteReader();
            List<ResourcesModel> resources = new List<ResourcesModel>();
            while (reader.Read())
            {
                resources.Add(new ResourcesModel
                {
                    ResourceId = (string)reader["Id"],
                    ResourceName = (string)reader["ResourceName"],
                    ResourceType = (string)reader["ResourceType"],
                    ResourceDescription = (string)reader["Resource Description"],
                    Quantity = (int)reader["Quantity"],
                    UnitId = (string)reader["UnitId"]
                });
            }
            Con.Close();
            return resources;
        }

    }
}
