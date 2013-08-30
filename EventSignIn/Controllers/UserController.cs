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
        public PartialViewResult CreateForm(string emailAddress, bool? admin)
        {
            if (admin.GetValueOrDefault())
            {
                ViewBag.IsAdmin = true;
            }

            return PartialView("_CreateForm", new UserModel { EmailAddress = emailAddress });
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

        [HttpPost]
        public JsonResult LookupUser(string emailAddress)
        {
            return new JsonResult
                {
                    Data = _userDataAccess.GetUserByEmail(emailAddress),
                };
        }
    }
}
