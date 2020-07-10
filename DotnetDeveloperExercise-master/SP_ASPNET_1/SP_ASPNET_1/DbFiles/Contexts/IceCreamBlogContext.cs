using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using SP_ASPNET_1.Models;
using SP_ASPNET_1.ViewModels;

namespace SP_ASPNET_1.DbFiles.Contexts
{
    public class IceCreamBlogContext: IdentityDbContext<ApplicationUser>
    {
        public IceCreamBlogContext() : base("name=IceCreamBlogDB")
        {

        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<ProductLine> ProductLines { get; set; }
        public DbSet<ProductItem> ProductItems { get; set; }
        public virtual DbSet<BlogPostReaction> BlogPostReactions { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<IceCreamBlogContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();


            modelBuilder.Entity<BlogPost>()
               .HasMany(e => e.BlogPostReactions)
               .WithRequired(e => e.BlogPost)
               .HasForeignKey(e=>e.BlogPostID)
               .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
        public static IceCreamBlogContext Create()
        {
            return new IceCreamBlogContext();
        }
    }
}