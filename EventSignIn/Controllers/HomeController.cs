using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventSignIn.DataAccess;
using EventSignIn.Models;

namespace EventSignIn.Controllers
{
    public class HomeController : Controller
    {
        EventDataAccess _eventDataAccess = new EventDataAccess();
        UserDataAccess _userDataAccess = new UserDataAccess();

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var model = new SummaryModel
                {
                    Users = _userDataAccess.GetUsers(),
                        Events = _eventDataAccess.GetEvents(),
                };
            return View(model);
        }
    }
}
