using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventSignIn.DataAccess;
using EventSignIn.Models;

namespace EventSignIn.Controllers
{
    public class CategoryController : Controller
    {
        CategoryDataAccess _categoryDataAccess = new CategoryDataAccess();

        public ActionResult Index()
        {
            var categories = _categoryDataAccess.GetCategories();
            return View(categories);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryModel category)
        {
            try
            {
                _categoryDataAccess.AddCategory(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryDataAccess.GetCategoryById(id);
            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(CategoryModel category)
        {
            try
            {
                _categoryDataAccess.UpdateCategory(category);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
