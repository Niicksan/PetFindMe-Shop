using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetFindMeShop.Data;
using PetFindMeShop.Data.Models;
using PetFindMeShop.Services.Interfaces;
using PetFindMeShop.Services.Mapping;
using PetFindMeShop.ViewModels;
using PetFindMeShop.Web.Infrastructure.Extensions;
using PetFindMeShop.Web.Infrastructure.Filters;
using PetFindMeShop.Web.Infrastructure.ModelBinders;
using System.Reflection;
using static PetFindMeShop.Common.GeneralApplicationConstants;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add Default connectionString.
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Add DbContext to the container.
builder.Services.AddDbContext<PetFindMeShopDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Identity
builder.Services.AddDefaultIdentity<Customer>(options =>
{
    options.SignIn.RequireConfirmedAccount =
        builder.Configuration.GetValue<bool>("Identity:SignIn:RequireConfirmedAccount");
    options.Password.RequireLowercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireLowercase");
    options.Password.RequireUppercase =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireUppercase");
    options.Password.RequireNonAlphanumeric =
        builder.Configuration.GetValue<bool>("Identity:Password:RequireNonAlphanumeric");
    options.Password.RequiredLength =
        builder.Configuration.GetValue<int>("Identity:Password:RequiredLength");
})
.AddRoles<IdentityRole<Guid>>()
.AddEntityFrameworkStores<PetFindMeShopDbContext>();

// Register Services
builder.Services.AddApplicationServices(typeof(IProductService));

// Register Filters
builder.Services.AddScoped<ProductExistsValidationFilter>();

builder.Services.AddMemoryCache();
builder.Services.AddResponseCaching();

builder.Services.ConfigureApplicationCookie(cfg =>
{
    cfg.LoginPath = "/Identity/Account/Login";
    cfg.AccessDeniedPath = "/Home/Error/401";
});

builder.Services
    .AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

WebApplication app = builder.Build();

// Add Custom Auto Mapper
AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error{0}");

    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.SeedAdministrator(DevelopmentAdminEmail);
}

app.UseEndpoints(config =>
{
    config.MapControllerRoute(
        name: "Areas",
        pattern: "/{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    config.MapControllerRoute(
         name: "default",
         pattern: "{controller=Home}/{action=Index}/{id?}");

    config.MapDefaultControllerRoute();
    config.MapRazorPages();
});

app.MapRazorPages();

app.Run();
