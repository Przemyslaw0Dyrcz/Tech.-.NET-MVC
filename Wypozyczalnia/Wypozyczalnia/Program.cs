using Microsoft.EntityFrameworkCore;
using Wypozyczalnia.Models;
using Wypozyczalnia.Repositories;
using FluentValidation.AspNetCore;
using FluentValidation;
using Wypozyczalnia.Mappings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection11")));



builder.Services.AddScoped<IKlientRepository, KlientRepository>(); 
builder.Services.AddScoped<IKlientService, KlientService>();       
builder.Services.AddScoped<ISprzetRepository, SprzetRepository>();
builder.Services.AddScoped<ISprzetService, SprzetService>();
builder.Services.AddScoped<IWypozyczenieRepository, WypozyczenieRepository>();
builder.Services.AddScoped<IWypozyczenieService, WypozyczenieService>();
builder.Services.AddControllersWithViews();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddValidatorsFromAssemblyContaining<WypozyczenieViewModelValidator>();
builder.Services.AddAutoMapper(typeof(MappingProfile));





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
