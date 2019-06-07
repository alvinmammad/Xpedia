using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class Driver
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Photo { get; set; }
        public string Fullname { get; set; }
        public int Age { get; set; }
        public int ExperienceYear { get; set; }
    }
}