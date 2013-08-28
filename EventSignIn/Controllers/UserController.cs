using System.Web.Mvc;
using EventSignIn.DataAccess;
using EventSignIn.Models;

namespace EventSignIn.Controllers
{
    public class UserController : Controller
    {
        UserDataAccess _userDataAccess = new UserDataAccess();

        public ActionResult View(int id, bool? admin)
        {
            if (admin.GetValueOrDefault())
            {
                ViewBag.IsAdmin = true;
            }

            var user = _userDataAccess.GetUserById(id);

            return View(user);
        }

        //
        // GET: /Event/Create
        public PartialViewResult CreateForm()
        {
            return PartialView("_CreateForm");
        }

        //
        // POST: /Event/Create
        [HttpPost]
        public ActionResult Create(UserModel newUser)
        {
            try
            {
                var newId = _userDataAccess.CreateUser(newUser);
                return RedirectToAction("View", "User", new { id = newId });
            }
            catch
            {
                ViewBag.Error =
                    "There was an error creating the user, please review the fields below and correct any mistakes.";
                return View(newUser);
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
