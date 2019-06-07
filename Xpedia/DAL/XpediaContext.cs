using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Xpedia.Models;
using Xpedia.Areas.Manage.Models;

namespace Xpedia.DAL
{
    public class XpediaContext:DbContext
    {
        public XpediaContext():base("XpediaContext")
        {

        }

        #region UI

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<LogoSlider> LogoSliders { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogCategory> BlogCategories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Blockquote> Blockquotes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<ServiceCard> ServiceCards { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<TestimonialItem> TestimonialItems { get; set; }
        public DbSet<TestimonialRole> TestimonialRoles { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamCategory> TeamCategories { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<AboutStory> AboutStories { get; set; }
        public DbSet<Fact> Facts { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<FeaturedDestination> FeaturedDestinations { get; set; }
        public DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }

        #endregion
       

        #region Back
        public DbSet<Admin> Admins { get; set; }
        #endregion
    }
}