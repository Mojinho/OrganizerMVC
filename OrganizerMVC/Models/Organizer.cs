using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.DynamicData;

namespace OrganizerMVC.Models
{
    [TableName("Organizer")]
    public sealed class Organizer : ModelBase
    {
        public Organizer()
        {
            OrganizerEvents = new HashSet<OrganizerEvent>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; }

        public ICollection<OrganizerEvent> OrganizerEvents { get; set; }
    }
}