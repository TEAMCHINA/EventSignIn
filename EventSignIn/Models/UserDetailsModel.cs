using System.Collections.Generic;

namespace EventSignIn.Models
{
    public class UserDetailsModel
    {
        public UserModel User { get; set; }
        public IList<EventModel> Events { get; set; } 
    }
}