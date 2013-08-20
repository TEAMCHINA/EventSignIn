using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventSignIn.Models;

namespace EventSignIn.Controllers
{
    public class HomeController : Controller
    {
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
                        Events = new List<EventModel>
                            {
                                new EventModel
                                    {
                                        Date = new DateTime(2013, 8, 16),
                                        Location = "Paradise Perks",
                                        Name = "Board Game Night",
                                        Description = "A night of board games!",
                                    }
                            }
                };
            return View(model);
        }

        //
        // GET: /Home/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Home/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Home/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Home/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Home/Edit/5

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
        // GET: /Home/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Home/Delete/5

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
