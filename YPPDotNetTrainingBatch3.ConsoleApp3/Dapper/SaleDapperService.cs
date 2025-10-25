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
    public class SaleDapperService
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

                string query = @"SELECT [SaleId]
               ,[ProductId]
               ,[Quantity]
               ,[Price]
               ,[DeleteFlag]
              ,[CreatedDateTime]
               ,[ModifiedDateTime]
              FROM [dbo].[Tbl_Sale]";

                List<SaleDto> lst = db.Query<SaleDto>(query).ToList();
                for (int i = 0; i < lst.Count; i++)
                {
                    var item = lst[i];
                    Console.WriteLine("SaleId =>" + item.SaleId);
                    Console.WriteLine("ProductId =>" + item.ProductId);
                    Console.WriteLine("Quantity =>" + item.Quantity);
                    Console.WriteLine("Price =>" + item.Price);
                }
            }

        }

        public void Create()
        {
            using (IDbConnection db = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
            {
                db.Open();
     
                string query = @"INSERT INTO [dbo].[Tbl_Sale]
           ([ProductId]
           ,[Quantity]
           ,[Price]
           ,[DeleteFlag]
           ,[CreatedDateTime]
           ,[ModifiedDateTime])   
     VALUES
           (14
           ,1
           ,12000
           ,0
           ,GETDATE()
           ,NULL)";

                int result = db.Execute(query);
                string message = result > 0 ? "Saving  Success." : "Saving Failed.";

                Console.WriteLine(message);
            }
        }

    }
}

    public class SaleDto
    {
        string query = @"SELECT [SaleId]
         ,[ProductId]
         ,[Quantity]
         ,[Price]
         ,[DeleteFlag]
        ,[CreatedDateTime]
         ,[ModifiedDateTime]
        FROM [dbo].[Tbl_Sale]";

        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public bool DeleteFlag { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
    }


