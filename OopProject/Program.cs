using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Container;
using DataLayer.Abstract;
using DataLayer.Concretes.EntityFramework;
using DataLayer.DataBase;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Authorization;

var builder = WebApplication.CreateBuilder(args);


#region Scoopeds
// Add services to the container.
//builder.Services.AddScoped<IServiceService, ServiceManager>();
//builder.Services.AddScoped<IServiceDal, EfServiceDal>();

//builder.Services.AddScoped<ITeamService, TeamManager>();
//builder.Services.AddScoped<ITeamDal, EfTeamDal>();

//builder.Services.AddScoped<INewsService, NewsManager>();
//builder.Services.AddScoped<INewsDal, EfNewsDal>();

//builder.Services.AddScoped<IImageService, ImageManager>();
//builder.Services.AddScoped<IImageDal, EfImageDal>();

//builder.Services.AddScoped<IAddressService, AddressManager>();
//builder.Services.AddScoped<IAddressDal, EfAddressDal>();

//builder.Services.AddScoped<IContactService, ContactManager>();
//builder.Services.AddScoped<IContactDal, EfContactDal>();

//builder.Services.AddScoped<ISocialMediaService, SocialMediaManager>();
//builder.Services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();

//builder.Services.AddScoped<IAboutService, AboutManager>();
//builder.Services.AddScoped<IAboutDal, EfAboutDal>();

//builder.Services.AddScoped<IAdminService, AdminManager>();
//builder.Services.AddScoped<IAdminDal, EfAdminDal>();

#endregion


builder.Services.AddDbContext<ProjectContext>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ProjectContext>();

builder.Services.AddControllersWithViews();

builder.Services.ContainerDependencies();
builder.Services.AddMvc(config =>
{
    var policy = new AuthorizationPolicyBuilder()
                   .RequireAuthenticatedUser()
                   .Build();

    config.Filters.Add(new AuthorizeFilter(policy));
});

builder.Services.AddMvc();

builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme
    ).AddCookie(x =>
    {
        x.LoginPath = "/Login/Index/";
    });

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Index";
});

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
