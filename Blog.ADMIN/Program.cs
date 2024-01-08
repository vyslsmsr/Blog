using Blog.ADMIN.Controllers;
using Blog.DATA.Context;
using Blog.DATA.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
/// bu alaný ekledik
var provider = builder.Services.BuildServiceProvider();
var configuration = provider.GetRequiredService<IConfiguration>();

builder.Services.AddDbContext<Conn>(item => item.UseSqlServer(configuration.GetConnectionString("Connection"), y => y.MigrationsAssembly("Blog.ADMIN")));
builder.Services.AddIdentity<AppUser, AppRole>(x =>
{
	x.Password.RequiredLength = 6;
	x.Password.RequireNonAlphanumeric = false;
	x.Password.RequireLowercase = false;
	x.Password.RequireUppercase = false;
	x.Password.RequireDigit = false;
	x.Password.RequiredUniqueChars = 0;

}).AddEntityFrameworkStores<Conn>().AddDefaultTokenProviders();
builder.Services.AddMvc();
builder.Services.AddTransient<HelperController>();
builder.Services.AddSession(options => { options.IdleTimeout = TimeSpan.FromMinutes(300); });

CookieBuilder cookieBuilder = new CookieBuilder()
{
	Name = "MyCookie",
	HttpOnly = false,
	SameSite = SameSiteMode.Lax,
	SecurePolicy = CookieSecurePolicy.SameAsRequest
};

builder.Services.ConfigureApplicationCookie(x =>
{
	x.LoginPath = new PathString("/login");
	x.Cookie = cookieBuilder;
	x.SlidingExpiration = true;
	x.ExpireTimeSpan = System.TimeSpan.FromDays(60);
	x.AccessDeniedPath = new PathString("/access-denied");
});
/// bu alaný ekledik


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// bulaný ekledik
app.UseHttpsRedirection();
app.UseStatusCodePages();
app.UseStaticFiles();
app.UseSession();
// bulaný ekledik

app.UseRouting();


// bulaný ekledik
app.UseRouting();
app.UseCookiePolicy();
app.UseAuthentication();
// bulaný ekledik
app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
