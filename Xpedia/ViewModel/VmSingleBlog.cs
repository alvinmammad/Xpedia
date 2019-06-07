using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Xpedia.Models;
namespace Xpedia.ViewModel
{
    public class VmSingleBlog
    {
        public Blog Blog { get; set; }
        public Blockquote Blockquote { get; set; }
        public List<Comment> Comments { get; set; }
        public Author Author { get; set; }
    }
}