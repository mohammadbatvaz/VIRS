using Microsoft.EntityFrameworkCore;
using System.Globalization;
using VIRS.Domain.AppServices;
using VIRS.Domain.Core.Calendar.Contracts.Services;
using VIRS.Domain.Core.CarAgg.Contracts.Data;
using VIRS.Domain.Core.CarAgg.Contracts.Services;
using VIRS.Domain.Core.CarModelAgg.Contracts.AppServices;
using VIRS.Domain.Core.CarModelAgg.Contracts.Data;
using VIRS.Domain.Core.CarModelAgg.Contracts.Services;
using VIRS.Domain.Core.CarOwnerAgg.Contracts.Data;
using VIRS.Domain.Core.CarOwnerAgg.Contracts.Services;
using VIRS.Domain.Core.ImageAgg.Contracts.Data;
using VIRS.Domain.Core.ImageAgg.Contracts.Services;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.AppServices;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.Data;
using VIRS.Domain.Core.InspectionRequestAgg.Contracts.Services;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.AppServices;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.Data;
using VIRS.Domain.Core.SystemAdminAgg.Contracts.Services;
using VIRS.Domain.Services;
using VIRS.Infra.DataAccess.EFCore;
using VIRS.Infra.DataAccess.Storage;
using VIRS.Infra.DataBase.EFCoreSqlServer;

var builder = WebApplication.CreateBuilder(args);


// Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

// Dependency Injection for AppServices
builder.Services.AddScoped<ICarModelAppServices, CarModelAppServices>();
builder.Services.AddScoped<IInspectionRequestAppServices, InspectionRequestAppServices>();
builder.Services.AddScoped<ISystemAdminAppServices, SystemAdminAppServices>();

// Dependency Injection for Services
builder.Services.AddScoped<ICarModelServices, CarModelServices>();
builder.Services.AddScoped<IInspectionRequestServices, InspectionRequestServices>();
builder.Services.AddTransient<ICalendarServices, CalendarServices>();
builder.Services.AddScoped<ICarOwnerServices, CarOwnerServices>();
builder.Services.AddScoped<ICarServices, CarServices>();
builder.Services.AddScoped<ISystemAdminServices, SystemAdminServices>();
builder.Services.AddScoped<IImageServices, ImageServices>();
builder.Services.AddScoped<PersianCalendar>();

// Dependency Injection for Repositories
builder.Services.AddScoped<ICarModelRepository, CarModelRepository>();
builder.Services.AddScoped<IInspectionRequestRepository, InspectionRequestRepository>();
builder.Services.AddScoped<ICarOwnerRepository, CarOwnerRepository>();
builder.Services.AddScoped<ICarRepository, CarRepository>();
builder.Services.AddScoped<ISystemAdminRepository, SystemAdminRepository>();
builder.Services.AddScoped<IFileRepository, FileRepository>();



// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Reservation}/{action=index}/{id?}")
    .WithStaticAssets();


app.Run();
