using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.ComponentModel.DataAnnotations.Schema;
namespace Xpedia.Models
{
    public class Location
    {
        [Required(ErrorMessage ="Boş olmamalıdır")]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Car> Cars { get; set; }
    }
}