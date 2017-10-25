using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WeddingSite.Models.Entities
{
    public class RSVP
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int NumAttendees { get; set; }
        [Required]
        public string Attendees { get; set; }
        public string Songs { get; set; }
    }
}
