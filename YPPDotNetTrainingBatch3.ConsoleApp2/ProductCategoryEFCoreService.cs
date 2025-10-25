using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPPDotNetTrainingBatch3.ConsoleApp2
{
    public class ProductCategoryEFCoreService
    {
        public void Read()
        {
            using var db = new AppDbContext();
            var categories = db.Tbl_ProductCategory.ToList();

            foreach (var category in categories)
            {
                Console.WriteLine(category.ProductCategoryId);
                Console.WriteLine(category.ProductCategoryCode);
                Console.WriteLine(category.ProductCategoryName);
            }
        }

        public void Create()
        {
            using var db = new AppDbContext();
            var category = new Tbl_ProductCategory
            {
                ProductCategoryCode = "ELEC",
                ProductCategoryName = "Electronics"
            };
            db.Tbl_ProductCategory.Add(category);
            int result = db.SaveChanges();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update()
        {
            using var db = new AppDbContext();
            var category = db.Tbl_ProductCategory.FirstOrDefault(x => x.ProductCategoryId == 1);
            if (category is null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            category.ProductCategoryName = "Updated Electronics";
            int result = db.SaveChanges();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            using var db = new AppDbContext();
            var category = db.Tbl_ProductCategory.FirstOrDefault(x => x.ProductCategoryId == 2);
            if (category is null)
            {
                Console.WriteLine("Category not found.");
                return;
            }

            db.Tbl_ProductCategory.Remove(category);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleting Successful." : "Deleting Failed.";
            Console.WriteLine(message);
        }
    }

}
