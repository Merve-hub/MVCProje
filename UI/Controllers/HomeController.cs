using DataAccess.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        ProductService productService = new ProductService();
        SubCategoryService subCategoryService = new SubCategoryService();
        CategoryService categoryService = new CategoryService();
        public ActionResult Index()
        {
            ViewBag.Categories = categoryService.GetActive();
            ViewBag.SubCategories = subCategoryService.GetActive();
            return View(productService.GetActive());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult GetProductsByCategory(Guid categoryId)
        {
            //var products = new List<Product>();
            //ViewBag.SubCategories = subCategoryService.GetActive();
            //foreach (var subCategory in subCategoryService.GetActive())
            //{
            //    if (subCategory.CategoryId == categoryId)
            //    {
            //        var result = productService.GetDefault(x => x.SubCategoryId == subCategory.ID);
            //        products.AddRange(result);
            //    }
            //}
            //return View(products);

            ViewBag.Categories = categoryService.GetActive();
            var list = productService.GetProductsByCategoryId(categoryId);
            return View(list);
        }
    }
}