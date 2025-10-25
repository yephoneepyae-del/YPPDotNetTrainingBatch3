using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPPDotNetTrainingBatch3.ConsoleApp3.Dapper
{
    public class ProductDapperService
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
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();

                string query = @"SELECT [ProductId]
                  ,[ProductName]
                  ,[Price]
                  ,[DeleteFlag]
              FROM [dbo].[Tbl_Product]";

                List<ProductDto> lst = db.Query<ProductDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    Console.WriteLine(lst[i].ProductName);
                    Console.WriteLine(lst[i].ProductId);
                }

            }
        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"INSERT INTO [dbo].[Tbl_Product]
           ([ProductId]
           ,[ProductName]
           ,[Price]
           ,[Quantity]
           ,[DeleteFlag])
     VALUES
           (16
           ,'Test3'
           ,500
           ,1
           ,0)";
                int result = db.Execute(query);
                string message = result > 0 ? "Saving  Success." : "Saving Failed.";

                Console.WriteLine(message);
            }
        }

        public void Update()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"UPDATE [dbo].[Tbl_Product]
   SET
     [ProductName] ='Test2'
      ,[Price] = 20000
      ,[Quantity] = 2

 WHERE ProductId = 10";
                int result = db.Execute(query);
                string message = result > 0 ? "Updating  Success." : "Updating Failed.";

                Console.WriteLine(message);
            }

        }

        public void Delete()
        {
             using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
                string query = @"Delete from Tbl_Product WHERE Productid = 11";
                int result = db.Execute(query);
                string message = result > 0 ? "Deleting  Success." : "Deleting Failed.";

                Console.WriteLine(message);
            }

        }
    }
    public class ProductDto
    {
        string query = @"SELECT [ProductId]
      ,[ProductName]
      ,[Price]
      ,[Quantity]
      ,[DeleteFlag]
  FROM [dbo].[Tbl_Product]";

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public bool DeleteFlag { get; set; }

    }
}
