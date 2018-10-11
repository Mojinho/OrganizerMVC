using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OrganizerMVC.ViewModels
{
    public class SportViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [DisplayName("Sport")]
        public string Name { get; set; }
    }
}