using System.Web.Mvc;
using EventSignIn.DataAccess;
using EventSignIn.Models;

namespace EventSignIn.Controllers
{
    public class EventController : Controller
    {
        CategoryDataAccess _categoryDataAccess = new CategoryDataAccess();
        EventDataAccess _eventDataAccess = new EventDataAccess();

        public ActionResult View(int id)
        {
            var currentEvent = _eventDataAccess.GetEventById(id);

            return View(currentEvent);
        }

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
        public ActionResult Create(EventModel newEvent, int categoryId)
        {
            newEvent.Category = _categoryDataAccess.GetCategoryById(categoryId);

            try
            {
                var newId = _eventDataAccess.CreateEvent(newEvent);
                return RedirectToAction("View", "Event", new { id = newId });
            }
            catch
            {
                ViewBag.Error =
                    "There was an error creating the event, please review the fields below and correct any mistakes.";
                var categories = _categoryDataAccess.GetCategories();
                ViewBag.Categories = categories;
                return View(newEvent);
            }
        }

        [HttpPost]
        public JsonResult RegisterUser(int eventId, int userId)
        {
            return new JsonResult
            {
                Data = _eventDataAccess.RegisterUserForEvent(eventId, userId)
            };
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
