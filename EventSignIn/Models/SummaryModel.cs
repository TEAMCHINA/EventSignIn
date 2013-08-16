using System.Collections.Generic;

namespace EventSignIn.Models
{
    public class SummaryModel
    {
        public IList<UserModel> Users { get; set; }
        public IList<EventModel> Events { get; set; } 
    }
}