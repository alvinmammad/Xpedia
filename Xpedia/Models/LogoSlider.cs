using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
namespace Xpedia.Models
{
    public class LogoSlider
    {
        public int ID { get; set; }
        [StringLength(maximumLength: 100)]
        public string Logo { get; set; }
    }
}