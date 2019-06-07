using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
using Xpedia.ViewModel;
namespace Xpedia.ViewModel
{
    public class VmOrder
    {
        public string PickUpLocation { get; set; }
        public string DropOffLocation { get; set; }
        public DateTime PickUpDate { get; set; }
        public DateTime DropOffDate { get; set; }
        public Car SelectedCar { get; set; }
        public CarModel CarModel { get; set; }
        public Brand Brand { get; set; }
        public User User { get; set; }
        public int OrderNumber { get; set; }

    }
}