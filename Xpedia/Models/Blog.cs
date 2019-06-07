using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Xpedia.Models
{
    public class Blog
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength: 30)]
        public string Title { get; set; }
        public DateTime Date { get; set; }
        [StringLength(maximumLength: 120)]
        public string Info { get; set; }
        [Column(TypeName = "ntext")]
        public string Desc { get; set; }
        [StringLength(maximumLength:1000)]
        public string Slug { get; set; }
        [Column(TypeName ="ntext")]
        public string Photo { get; set; }
        public int AuthorID { get; set; }
        public int CategoryID { get; set; }
        public Author Author { get; set; }
        public BlogCategory Category { get; set; }
        public List<Comment> Comments { get; set; }
    }
}