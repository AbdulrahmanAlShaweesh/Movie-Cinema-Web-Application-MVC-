using CinemaMovieWebApplication.Data;
using CinemaMovieWebApplication.Data.Services;
using CinemaMovieWebApplication.Data.Services.Service;
using CinemaMovieWebApplication.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MovieCinemaDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MovieCinema"));
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<MovieCinemaDbContext>()
    .AddDefaultTokenProviders();

// Adding validtion 
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation().AddDataAnnotationsLocalization().AddViewLocalization();

builder.Services.AddScoped<IActorRepository, ActorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

MovieCinemaInitlize.Seeding(app.Services);

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Actors}/{action=GetAllActors}/{id?}");

app.Run();
