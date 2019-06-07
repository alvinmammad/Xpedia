using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class Service
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:25)]
        public string Title { get; set; }
        [StringLength(maximumLength:100)]
        public string Desc { get; set; }
    }
}