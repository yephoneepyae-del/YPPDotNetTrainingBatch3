using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace YPPDotNetTrainingBatch3.ConsoleApp3.Ado
{
    internal class SaleSqlService
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
            string query = @"SELECT [SaleId]
         ,[ProductId]
         ,[Quantity]
         ,[Price]
         ,[DeleteFlag]
        ,[CreatedDateTime]
         ,[ModifiedDateTime]
        FROM [dbo].[Tbl_Sale]";


            SqlConnection conncetion = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            conncetion.Open();

            SqlCommand cmd = new SqlCommand(query, conncetion);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            conncetion.Close();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                Console.WriteLine("SaleId => " + row["Saleid"]);
                Console.WriteLine("ProductId =>" + row["ProductId"]);
                Console.WriteLine("Quantity =>" + row["Quantity"]);
                Console.WriteLine("Price =>" + row["Price"]);
                Console.WriteLine("----------------------------------------");

            }
        }
        public void Create()
        {
            string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductId]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag]
           ,[CreatedDateTime]
           ,[ModifiedDateTime])
     VALUES
           (13
           ,1
           ,8000
           ,0
           ,GETDATE()
           ,NULL)";

            SqlConnection conncetion = new SqlConnection(sqlConnectionStringBuilder.ConnectionString);
            conncetion.Open();

            SqlCommand cmd = new SqlCommand(query, conncetion);
            int result = cmd.ExecuteNonQuery();
            conncetion.Close();
            string message = result > 0 ? "Saving  Success." : "Saving Failed.";

            Console.WriteLine(message);

        }
       
    }
}
