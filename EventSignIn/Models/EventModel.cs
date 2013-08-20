using System;
using System.Collections.Generic;

namespace EventSignIn.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public IList<UserModel> Attendees { get; set; }
    }
}