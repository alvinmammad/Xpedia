using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Xpedia.Models
{
    public class CarModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int BrandID { get; set; }
        public virtual Brand Brand { get; set; }
        public List<Car> Cars { get; set; }
    }
}