using ileriRepository.Context;
using ileriRepository.Data;
using ileriRepository.Models;
using ileriRepository.Repositories.Abstract;
using ileriRepository.Repositories.Concretes;
using ileriRepository.UnitofWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<MyContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("Baglanti")));
builder.Services.AddScoped<IPersonelRep, PersonelRep<Personel>>();
builder.Services.AddScoped<IGradeRep, GradeRep<Grade>>();
builder.Services.AddScoped<ICityRep, CityRep<City>>();
builder.Services.AddScoped<ICountyRep, CountyRep<County>>();
builder.Services.AddScoped<IDepartmentRep, DepartmentRep<Department>>();
builder.Services.AddScoped<IUnit, Unit>();
builder.Services.AddScoped<CityModel>();
builder.Services.AddScoped<CountyModel>();
builder.Services.AddScoped<DepartmentModel>();
builder.Services.AddScoped<GradeModel>();
builder.Services.AddScoped<List<City>>();
//depency injection of version?? //interface üzerinden newlemek. programda bir kere tanýtýlýp kullanýlmasýný saðlar.(ör:cityrep ve cityrep2 den istediðimizi ICityRep ile kullanýyoruz.)
// new lemek = instance yaratmak demektir.

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
