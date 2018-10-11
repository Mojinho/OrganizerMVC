using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrganizerMVC.Models
{
    public sealed class Sport : ModelBase
    {
        public Sport()
        {
            Events = new HashSet<Event>();
        }

        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<Event> Events { get; set; }
    }
}