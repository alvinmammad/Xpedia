using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Xpedia.Models
{
    public class BlogCategory
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:15)]
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}