using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class AboutStory
    {
        [Required]
        public int ID { get; set; }
        public string Title { get; set; }
        [StringLength(350)]
        public string Desc { get; set; }
        public string Photo { get; set; }
        public string Signature { get; set; }
    }
}