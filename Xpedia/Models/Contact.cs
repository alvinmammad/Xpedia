using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

namespace Xpedia.Models
{
    public class Contact
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:20)]
        public string Title { get; set; }
        [StringLength(maximumLength:100)]
        public string Desc { get; set; }
        [StringLength(maximumLength: 80)]
        public string Address { get; set; }
        [StringLength(maximumLength: 25)]
        public string Phone { get; set; }
        [StringLength(maximumLength:35)]
        public string Email { get; set; }
    }
}