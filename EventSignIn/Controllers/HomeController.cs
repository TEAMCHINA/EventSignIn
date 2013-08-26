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

        //
        // GET: /Home/
        public ActionResult Index()
        {
            var model = new SummaryModel
                {
                    Users = new List<UserModel>
                        {
                            new UserModel
                                {
                                    FirstName = "Lisa",
                                    LastName = "Ly",
                                    EmailAddress = "ladyautodidact@gmail.com",
                                    EmailOptIn = true,
                                    GraduationYear = 2003,
                                },
                            new UserModel
                                {
                                    FirstName = "Cliff",
                                    LastName = "Chinn",
                                    EmailAddress = "monkeyhateclean@gmail.com",
                                    EmailOptIn = true,
                                    GraduationYear = 2002,
                                    Notes = "Graduated from UW!",
                                },
                        },
                        Events = _eventDataAccess.GetEvents(),
                };
            return View(model);
        }
    }
}
