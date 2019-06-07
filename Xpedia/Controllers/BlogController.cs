using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xpedia.Models;
using Xpedia.ViewModel;
using System.Data.Entity;
namespace Xpedia.Controllers
{
    public class BlogController : BaseController
    {
        public ActionResult Blog(int? category,int? Month , int? Year , int page=1)
        {
            VmBlog model = new VmBlog();
            model.TotalPage = Convert.ToInt32(Math.Ceiling(_context.Blogs.Count() / 4.0));
            if (page<1 || page>model.TotalPage)
            {
                return HttpNotFound();
            }
            model.Blogs = _context.Blogs.Include(b => b.Author).
                Where(b => (category != null ? b.CategoryID == category : true) &&
                (Month != null ? b.Date.Month == Month : true) &&
                (Year != null ? b.Date.Year == Year : true)).
                OrderByDescending(b => b.Date).Skip((page-1)*4).Take(4).ToList();
            model.Categories = _context.BlogCategories.ToList();
            model.Category = category;
            model.Month = Month;
            model.Year = Year;
            model.Archives = _context.Blogs.Where(b => (category != null ? b.CategoryID == category : true) && (Month != null ? b.Date.Month == Month : true) && (Year != null ? b.Date.Year == Year : true)).GroupBy(b => new { b.Date.Year, b.Date.Month }).Select(g => new Archive { Year = g.Key.Year, Month = g.Key.Month }).OrderByDescending(g => g.Year).ThenByDescending(g => g.Month).ToList();
            model.Page = page;
            return View(model);
        }


        public ActionResult BlogDetail(string slug)
        {
            if (string.IsNullOrEmpty(slug))
            {
                return HttpNotFound();
            }
            VmSingleBlog model = new VmSingleBlog();
            model.Blog = _context.Blogs.Include(b=>b.Author).FirstOrDefault(s => s.Slug == slug);
            model.Author = _context.Authors.FirstOrDefault();
            model.Comments = _context.Comments.ToList();
            model.Blockquote = _context.Blockquotes.First();
            ViewBag.Blogs = _context.Blogs.ToList();
            if (model.Blog==null)
            {
                return HttpNotFound();
            }
            return View(model);
        }
        public ActionResult Comments(string Author, string Body, int BlogID, string Slug)
        {
            Comment comment = new Comment();
            comment.Author = Author;
            comment.Body = Body;
            comment.BlogID = BlogID;
            comment.Date = DateTime.Now;
            _context.Comments.Add(comment);
            _context.SaveChanges();
            return RedirectToAction("blogdetail", new { slug = Slug });
        }
    }
}