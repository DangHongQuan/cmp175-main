using cpm175.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Amazon.S3;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var serverVersion = new MySqlServerVersion(new Version(8, 2, 12));
builder.Services.AddDbContext<ApplicationDbContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);
builder.Services.AddDefaultAWSOptions(builder.Configuration.GetAWSOptions());
builder.Services.AddAWSService<IAmazonS3>();


builder.Services.AddScoped<IVideoUrlRepository, EFVideoUrlRpository>();
builder.Services.AddScoped<ISourceRepository, EFSourceRepository>();
builder.Services.AddDefaultIdentity<IdentityUser>()
    .AddRoles<IdentityRole>() // Thêm dòng này để cấu hình việc sử dụng IdentityRole
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();
builder.Services.AddDistributedMemoryCache();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();