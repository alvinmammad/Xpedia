using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class ServiceCard
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:25)]
        public string Title { get; set; }
        [StringLength(maximumLength:70)]
        public string Info { get; set; }
        [StringLength(maximumLength:30)]
        public string Icon { get; set; }
    }
}