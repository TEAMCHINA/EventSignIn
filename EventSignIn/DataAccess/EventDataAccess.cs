using System;
using System.Collections.Generic;
using System.Linq;
using EventSignIn.Models;

namespace EventSignIn.DataAccess
{
    public class EventDataAccess
    {
        CategoryDataAccess _categoryDataAccess = new CategoryDataAccess();
        UserDataAccess _userDataAccess = new UserDataAccess();

        public IList<EventModel> GetEvents()
        {
            using (var db = new EventSignInEntities())
            {
                var categories = _categoryDataAccess.GetCategories()
                                                    .ToDictionary(c => c.Id, c => c);

                var users = _userDataAccess.GetUsers()
                                           .ToDictionary(u => u.Id, u => u);

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
                        Attendees = e.EventAttendances.Select(user => users[user.UserId])
                            .ToList(),
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

            return e;
        }

        public int CreateEvent(EventModel e)
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

                return newEvent.Id;
            }
        }

        public bool RegisterUserForEvent(int eventId, int userId)
        {
            using (var db = new EventSignInEntities())
            {
                if (db.EventAttendances.Any(e => e.EventId == eventId && e.UserId == userId))
                {
                    return true; // Already registered.
                }

                try
                {
                    db.EventAttendances.Add(new EventAttendance
                        {
                            EventId = eventId,
                            UserId = userId,
                        });

                    db.SaveChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }
    }
}