//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EventSignIn.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public Event()
        {
            this.EventAttendances = new HashSet<EventAttendance>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public System.DateTime Date { get; set; }
        public string Location { get; set; }
        public int Category { get; set; }
    
        public virtual Category Category1 { get; set; }
        public virtual ICollection<EventAttendance> EventAttendances { get; set; }
    }
}
