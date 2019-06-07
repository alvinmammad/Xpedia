using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class TestimonialRole
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:20)]
        public string Name { get; set; }
        public List<TestimonialItem> TestimonialItems { get; set; }
    }
}