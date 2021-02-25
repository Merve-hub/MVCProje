using Core.Service;
using DataAccess.Context;
using DataAccess.Entities;
using Service.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repository
{
    public class ProductService:BaseService<Product> 
    {
        //Aylık rapor

        //Kampanyalı ürünler

        //Stoğu azalanlar
        ProjectDbContext db = Singleton.Context;
        public List<ProductDetail> GetProductsByCategoryId(Guid categoryId)
        {
            var result = from product in db.Products
                         join subCategory in db.SubCategories on product.SubCategoryId equals subCategory.ID
                         join category in db.Categories on subCategory.CategoryId equals category.ID
                         where category.ID == categoryId
                         select new ProductDetail()
                         {
                             ProductId=product.ID,
                             ProductName = product.ProductName,
                             UnitPrice = product.UnitPrice,
                             UnitsInStock = product.UnitsInStock,
                             SubCategoryName = subCategory.SubCategoryName,
                             CategoryName = category.CategoryName,
                             ImagePath = product.ImagePath
                         };
            return result.ToList();
        }
    }
}
