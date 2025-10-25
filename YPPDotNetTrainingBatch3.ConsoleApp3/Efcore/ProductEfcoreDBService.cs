using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPPDotNetTrainingBatch3.ConsoleApp3.Efcore
{
    public class ProductEfcoreDBService 
    {
        private readonly AppDbMiniContext _db;

        public ProductEfcoreDBService()
        {

            _db = new AppDbMiniContext();
        }

        public void Read()
        {
            AppDbMiniContext db = new AppDbMiniContext();
            var lst = db.Product.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++)
            {
                Console.WriteLine(lst[i].ProductName);
                Console.WriteLine(lst[i].ProductId);
                Console.WriteLine(lst[i].Price);
                Console.WriteLine(lst[i].Quantity);
            }

        }

        public void Create()
        {
            AppDbMiniContext db = new AppDbMiniContext();
            var item = new Tbl_Product()
            {
                ProductName = "Orange",
                ProductId = 18,
                Price = 8000,
                Quantity = 100,
                DeleteFlag = false,
            };
            db.Product.Add(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving  Success." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            //Linq
            AppDbMiniContext db = new AppDbMiniContext();
            var item = db.Product.FirstOrDefault(x => x.ProductId > 11);
           
            if (item == null)
            {
                return;

            }

            item.ProductName = "apple";
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating  Success." : "Updating Failed.";
            Console.WriteLine(message);

        }

    }
}
        
     