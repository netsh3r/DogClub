using DogClub.Entities;
using DogClub.Entities.Repositories;
using DogClub.Entities.Repositories.Implementations;
using DogClub.Services;
using DogClub.Settings;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient(typeof(EntityRepository<>));
builder.Services.AddPostgreSql<DogClubContext>(builder.Configuration);
builder.Services.AddTransient<DogService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

