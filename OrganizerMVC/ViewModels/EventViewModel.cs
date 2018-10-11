using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using OrganizerMVC.Models;

namespace OrganizerMVC.ViewModels
{
    public class EventViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(160)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Description")]
        public string Description { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("Start")]
        public DateTime StartDate { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DisplayName("End")]
        public DateTime EndDate { get; set; }

        [Url]
        [Required]
        [DisplayName("Image")]
        public string ImageUrl { get; set; }

        public Guid SportId { get; set; }

        [DisplayName("Sport")]
        public SportViewModel Sport { get; set; }}
}