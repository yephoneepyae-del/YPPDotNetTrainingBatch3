using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPPDotNetTrainingBatch3.ConsoleApp3.Efcore
{
    internal class SaleEfcoreDBService
    {
        private readonly AppDbMiniContext _db;

        public SaleEfcoreDBService()
        {

            _db = new AppDbMiniContext();
        }

        public void Read()
        {
            AppDbMiniContext db = new AppDbMiniContext();
            var lst = db.Sale.Where(x => x.ProductId == 17 && x.DeleteFlag == false).ToList();


            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].SaleId);
                Console.WriteLine(lst[i].ProductId);
                Console.WriteLine(lst[i].Quantity);
                Console.WriteLine(lst[i].Price);
            }

        }

        public void Create()
        {
            AppDbMiniContext db = new AppDbMiniContext();
            var item = new Tbl_Sale()
            {
                ProductId = 6,
                Quantity = 3,
                Price = 9000,
                DeleteFlag = false
            };

            db.Sale.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving  Success." : "Saving Failed.";
            Console.WriteLine(message);
        }
    }
}
