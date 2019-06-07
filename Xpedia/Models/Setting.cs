using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
namespace Xpedia.Models
{
    public class Setting
    {
        public int ID { get; set; }
        [StringLength(250)]
        public string Logo { get; set; }
        public string ChooseUsTitle { get; set; }
        public string ChooseUsDesc { get; set; }
        public string ChooseUsButtonText { get; set; }
        public string ChooseUsPhoto { get; set; }
    }
}