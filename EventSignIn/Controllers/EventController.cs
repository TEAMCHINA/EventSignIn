using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventSignIn.DataAccess;
using EventSignIn.Models;

namespace EventSignIn.Controllers
{
    public class EventController : Controller
    {
        CategoryDataAccess _categoryDataAccess = new CategoryDataAccess();
        EventDataAccess _eventDataAccess = new EventDataAccess();

        //
        // GET: /Event/Create
        public PartialViewResult CreateForm()
        {
            var categories = _categoryDataAccess.GetCategories();
            ViewBag.Categories = categories;
            return PartialView("_CreateForm");
        }

        //
        // POST: /Event/Create

        [HttpPost]
        public JsonResult Create(EventModel newEvent, int categoryId)
        {
            try
            {
                newEvent.Category = _categoryDataAccess.GetCategoryById(categoryId);
                _eventDataAccess.CreateEvent(newEvent);

                return new JsonResult
                    {
                        Data = true
                    };
            }
            catch
            {
                return new JsonResult
                {
                    Data = false
                };
            }
        }

        //
        // GET: /Event/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Event/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Event/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Event/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
