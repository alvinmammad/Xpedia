using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.DAL;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmBlog
    {
        public List<Blog> Blogs{ get; set; }
        public List<BlogCategory> Categories { get; set; }
        public List<Archive> Archives { get; set; }
        public int TotalPage { get; set; }
        public int Page { get; set; }
        public int? Category { get; set; }
        public int? Year { get; set; }
        public int? Month { get; set; }
    }

    public class Archive
    {
        public int Year { get; set; }
        public int Month { get; set; }
    }
}