using System;
using System.Collections.Generic;

namespace EventSignIn.Models
{
    public class EventModel
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public IList<UserModel> Attendees { get; set; }
    }
}