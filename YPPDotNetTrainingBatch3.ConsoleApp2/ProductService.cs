using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPPDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductService
    {
        SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "Batch3MiniPOs",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        
        public void Read()
        {

           // SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
           // sqlConnectionStringBuilder.DataSource = ".";
           // sqlConnectionStringBuilder.InitialCatalog = "Batch3MiniPOs";
           // sqlConnectionStringBuilder.UserID = "sa";
            //sqlConnectionStringBuilder.Password = "sasa@123";
           // sqlConnectionStringBuilder.TrustServerCertificate = true;


            SqlConnection conncetion = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);

            conncetion.Open();

            string query = @"SELECT [ProductId]
                  ,[ProductName]
                  ,[Price]
                  ,[DeleteFlag]
              FROM [dbo].[Tbl_Product]";

            SqlCommand cmd = new SqlCommand(query, conncetion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conncetion.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                // Console.WriteLine(row["ProductId"]);
                Console.WriteLine("ProductName => " + row["ProductName"]);
                Console.WriteLine("Price =>" + row["Price"]);
                // Console.WriteLine(row["DeleteFlag"]);
                Console.WriteLine("----------------------------------------");

            }
        }

        public void Create()
        {
            string query = @"INSERT INTO[dbo].[Tbl_Product]
           ([ProductName]
           , [Price]
           , [DeleteFlag])
     VALUES
           ('Test'
           , 10000
           , 0)";

            SqlConnection conncetion = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            conncetion.Open();

            SqlCommand cmd = new SqlCommand(query, conncetion);
            int result = cmd.ExecuteNonQuery();


            conncetion.Close();
            string message = result > 0 ? "Saving  Success." : "Saving Failed.";

            Console.WriteLine(message);
        }

        public void Update()
        {
            string query = @"UPDATE [dbo].[Tbl_Product]
   SET [ProductName] = 'Test2'
      ,[Price] = 20000
     
 WHERE Productid = 10";

            SqlConnection conncetion = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            conncetion.Open();

            SqlCommand cmd = new SqlCommand(query, conncetion);
            int result = cmd.ExecuteNonQuery();


            conncetion.Close();
            string message = result > 0 ? "Updating  Success." : "Updating Failed.";

            Console.WriteLine(message);
        }

        public void Delete()
        {
            string query = @"Delete from Tbl_Product WHERE Productid = 11";

            SqlConnection conncetion = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            conncetion.Open();

            SqlCommand cmd = new SqlCommand(query, conncetion);
            int result = cmd.ExecuteNonQuery();


            conncetion.Close();
            string message = result > 0 ? "Deleting  Success." : "Deleting Failed.";

            Console.WriteLine(message);
        }
    }


}
