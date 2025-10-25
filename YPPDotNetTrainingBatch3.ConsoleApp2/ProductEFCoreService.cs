using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPPDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductEFCoreService
    {
        private readonly AppDbContext _db;

        public ProductEFCoreService()
        {
            _db = new AppDbContext();
            
        }
        public void Read()
        {
            AppDbContext db = new AppDbContext();
            var lst = db.Product.Where(x => x.DeleteFlag == false).ToList();

            for (int i = 0; i < lst.Count; i++) 
            { 
                Console.WriteLine(lst[i].ProductName);
                Console.WriteLine(lst[i].ProductId);
            }
            
        }
        

        public void Create()
        {
            AppDbContext db = new AppDbContext();
            var item = new Tbl_Product()
            {
                ProductName = "Test",
                Price = 10000,
                Quantity = 100,
                CreateDateTime = DateTime.Now,
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
            AppDbContext db = new AppDbContext();
            var item = db.Product.FirstOrDefault(x => x.ProductId > 9);
            //var item = db.Product.Where(x => x.ProductId > 9).FirstOrDefault();
            if (item == null) 
            {
                return;

            }

            item.ProductName = "apple";
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating  Success." : "Updating Failed.";
            Console.WriteLine(message);

        }

        public void Delete()
        {
            //Linq
            AppDbContext db = new AppDbContext();
            var item = db.Product.FirstOrDefault(x => x.ProductId == 10 );
            //var item = db.Product.Where(x => x.ProductId > 9).FirstOrDefault();
            if (item == null)
            {
                return;

            }
            //db.Remove(item);
            item.DeleteFlag = true;
            item.ModifiedDateTime = DateTime.Now;
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating  Success." : "Updating Failed.";
            Console.WriteLine(message);
        }
    }
}
