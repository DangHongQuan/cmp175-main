using cmp175.Models;
using LTW_Projeck_CPM174.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace cpm175.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Oder> Oders { get; set; }
        public DbSet<Source> Sources { get; set; }
        public DbSet<SourceReview>  SourceReview{ get; set; }
        public DbSet<VideoURL> VideoUrls { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<ContentDetail> ContentDetails { get; set; }
        public DbSet<ExampleContent> ExampleContents { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }

    }

}