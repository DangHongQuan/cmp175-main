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
        public DbSet<Sourse> Sources { get; set; }
        public DbSet<SourseReview>  SourseReview{ get; set; }
        public DbSet<VideoURL> VideoUrls { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Example> Examples { get; set; }
        public DbSet<ContentDetail> ContentDetails { get; set; }
        public DbSet<ExampleContent> ExampleContents { get; set; }

    }

}