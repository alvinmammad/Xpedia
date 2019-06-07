using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Xpedia.Models
{
    public class TeamCategory
    {
        [Required]
        public int ID { get; set; }
        [StringLength(maximumLength:30)]
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
    }
}