using System.Text.Json;
using TennisPlannet.Web.Service;
using TennisPlannet.Web.Service.IService;
using TennisPlannet.Web.Utils;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Registering Services
Common.CouponApiBase = builder.Configuration["ServiceUrls:Coupon.Api.Url"];
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<IBaseService, BaseService>();

builder.Services.AddHttpClient<ICouponService, CouponService>();
builder.Services.AddScoped<ICouponService, CouponService>();

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

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
