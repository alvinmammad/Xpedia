using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class Testimonial
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:15)]
        public string Title { get; set; }
        [StringLength(maximumLength:50)]
        public string Desc { get; set; }
    }
}