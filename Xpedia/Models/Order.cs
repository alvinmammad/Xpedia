using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using Xpedia.Models;
using Xpedia.DAL;
namespace Xpedia.Models
{
    public class Order
    {
        [Required]
        public int ID { get; set; }
        public int OrderNumber { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa maşını götürmə məntəqəsini daxil edin")]
        public string PickUpLocation { get; set; }
        [Required(ErrorMessage = "Zəhmət olmasa maşını qaytarma məntəqəsini daxil edin")]
        public string DropOffLocation { get; set; }
        [DataType(DataType.Date)]
        public DateTime PickUpDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime DropOffDate { get; set; }
        public bool IsConfirmed { get; set; }
        public bool DoFinish { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public int CarID { get; set; }
        public Car Car { get; set; }
    }
}