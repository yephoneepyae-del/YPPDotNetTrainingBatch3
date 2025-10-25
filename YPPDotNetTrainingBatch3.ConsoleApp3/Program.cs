// See https://aka.ms/new-console-template for more information
using Microsoft.Data.SqlClient;
using System.Data;
using YPPDotNetTrainingBatch3.ConsoleApp3;
using YPPDotNetTrainingBatch3.ConsoleApp3.Ado;
using YPPDotNetTrainingBatch3.ConsoleApp3.Dapper;
using YPPDotNetTrainingBatch3.ConsoleApp3.Efcore;

Console.WriteLine("Hello, World!");
//ProductSqlService productService = new ProductSqlService();
//productService.Read();
//productService.Create();
//productService.Update();
//productService.Delete();

//SaleSqlService saleSqlService = new SaleSqlService();
//saleSqlService.Read();
//saleSqlService.Create();

//ProductDapperService productDapperService = new ProductDapperService();
//ProductDapperService.Read();
//ProductDapperService.Create();
//ProductDapperService.Update();
//ProductDapperService.Delete();

//SaleDapperService saleDapperService = new SaleDapperService();
//saleDapperService.Read();
//saleDapperService.Create();

//ProductEfcoreDBService dbService = new ProductEfcoreDBService();
//dbService.Read();
//dbService.Create();


SaleEfcoreDBService dbservice = new SaleEfcoreDBService();
dbservice.Read();
dbservice.Create();

Console.ReadLine();