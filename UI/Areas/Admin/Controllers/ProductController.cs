using Common;
using DataAccess.Entities;
using Service.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UI.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        ProductService productService = new ProductService();
        SubCategoryService subCategoryService = new SubCategoryService();
        // GET: Admin/Product
        public ActionResult Index()
        {
            ViewBag.SubCategories = subCategoryService.GetActive();
            return View(productService.GetActive());
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            ViewBag.SubCategories = subCategoryService.GetActive();
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase ProductImage)
        {
            try
            {
                product.ImagePath = ImageUploader.UploadImage("~/Content/images/products/", ProductImage);
                productService.Add(product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(Guid id)
        {
            ViewBag.SubCategories = subCategoryService.GetActive();
            var updated = productService.GetById(id);
            return View(updated);
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            try
            {
                productService.Update(product);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(Guid id)
        {
            var deleted = productService.GetById(id);
            return View(deleted);
        }

        // POST: Admin/Product/Delete/5
        [HttpPost]
        public ActionResult Delete(Product product)
        {
            try
            {
                productService.Remove(product.ID);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
