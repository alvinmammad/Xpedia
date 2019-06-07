using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Xpedia.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Photo { get; set; }
        public string Fullname { get; set; }
        public int TeamCategoryID { get; set; }
        public TeamCategory TeamCategory { get; set;}
    }
}