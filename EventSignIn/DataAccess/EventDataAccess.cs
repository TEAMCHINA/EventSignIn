using System;
using System.Collections.Generic;
using System.Linq;
using EventSignIn.Models;

namespace EventSignIn.DataAccess
{
    public class EventDataAccess
    {
        CategoryDataAccess _categoryDataAccess = new CategoryDataAccess();

        public IList<EventModel> GetEvents()
        {
            using (var db = new EventSignInEntities())
            {
                var categories = _categoryDataAccess.GetCategories()
                                                    .ToDictionary(c => c.Id, c => c);

                var events = db.Events
                    .ToList();

                var eventModels = events.Select(e => new EventModel
                    {
                        Id = e.Id,
                        Name = e.Name,
                        Description = e.Description,
                        Location = e.Location,
                        Date = e.Date,
                        Category = categories[e.Category],
                    });

                return eventModels.ToList();
            }
        }

        public EventModel GetEventById(int id)
        {
            var e = GetEvents().FirstOrDefault(ev => ev.Id == id);

            if (e == null)
            {
                throw new InvalidOperationException(string.Format("Could not find Event with ID: {0}", id));
            }

            // TODO: Get users
            //e.Attendees = _userDataAccess.GetUsers();

            return e;
        }

        public void CreateEvent(EventModel e)
        {
            using (var db = new EventSignInEntities())
            {
                var newEvent = new Event
                    {
                        Name = e.Name,
                        Description = e.Description,
                        Location = e.Location,
                        Date = e.Date,
                        Category = e.Category.Id,
                    };

                db.Events.Add(newEvent);
                db.SaveChanges();
            }
        }
    }
}