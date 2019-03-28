using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace InvoiceManager
{
    class DBManager
    {
        private static DBManager instance;
        private string connectionString = @"Data Source=.\SQLExpress;Initial Catalog=QLHoaDon;Integrated Security=True";

        public static DBManager shared()
        {
            if (instance == null)
            {
                instance = new DBManager();
            }

            return instance;
        }

        private DBManager() { }

        public DataTable ExecuteQuery(String query)
        {
            DataTable data = new DataTable(); 
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(data);

                conn.Close();
            }

            return data;
        }

        public object ExecuteScalar(string query) {
            object data = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                data = cmd.ExecuteScalar();
                conn.Close();
            }
            return data;
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);
                data = cmd.ExecuteNonQuery();
                conn.Close();
            }
            return data;
        }
    }
}
