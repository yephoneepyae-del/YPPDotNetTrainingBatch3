// See https://aka.ms/new-console-template for more information

using Microsoft.Data.SqlClient;
using System.Data;

Console.WriteLine("Hello, World!");

SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
sqlConnectionStringBuilder.DataSource = ".";
sqlConnectionStringBuilder.InitialCatalog = "Batch3MiniPOs";
sqlConnectionStringBuilder.UserID = "sa";
sqlConnectionStringBuilder.Password = "sasa@123";
sqlConnectionStringBuilder.TrustServerCertificate = true;


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

for (int i =0; i < dt.Rows.Count; i++)
{
    DataRow row = dt.Rows[i];
    // Console.WriteLine(row["ProductId"]);
    Console.WriteLine("ProductName => " + row["ProductName"]);
    Console.WriteLine("Price =>" + row["Price"]);
    // Console.WriteLine(row["DeleteFlag"]);
    Console.WriteLine("----------------------------------------");

}


Console.ReadLine();