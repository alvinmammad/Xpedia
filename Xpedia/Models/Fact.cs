using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class Fact
    {
        [Required]
        public int ID { get; set; }
        public string Icon { get; set; }
        public int Key { get; set; }
        public string Value { get; set; }
    }
}