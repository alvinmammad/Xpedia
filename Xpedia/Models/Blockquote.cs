using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class Blockquote
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:50)]
        public string Background { get; set; }
        [StringLength(maximumLength:100)]
        public string Image { get; set; }
        [StringLength(maximumLength:50)]
        public string Title { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}