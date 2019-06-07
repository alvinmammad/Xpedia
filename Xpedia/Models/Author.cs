using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Xpedia.Models
{
    public class Author
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:30)]
        public string Fullname { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Blockquote> Blockquotes { get; set; }
    }
}