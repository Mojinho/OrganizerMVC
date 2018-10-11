using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace OrganizerMVC.Models
{
    [Table("OrganizerEvent")]
    public sealed class OrganizerEvent : ModelBase
    {
        [Key]
        public Guid Id { get; set; }

        [Index("IX_UniqueOrganizerEvent", 1, IsUnique = true)]
        public Guid OrganizerId { get; set; }

        [ForeignKey(nameof(OrganizerId))]
        public Organizer Organizer { get; set; }

        [Index("IX_UniqueOrganizerEvent", 2, IsUnique = true)]
        public Guid EventId { get; set; }

        [ForeignKey(nameof(EventId))]
        public Event Event { get; set; }
    }
}