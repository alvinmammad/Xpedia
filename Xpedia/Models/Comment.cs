using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
namespace Xpedia.Models
{
    public class Comment
    {
        public int ID { get; set; }
        [StringLength(maximumLength:250)]
        public string Body { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string Author { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}