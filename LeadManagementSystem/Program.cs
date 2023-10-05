using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Home controller Index Page Route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
    

//Lead controller Index Page Route

    app.MapControllerRoute(
    name: "Lead",
    pattern: "{controller=Lead}/{action=Index}/{id?}");

//Lead Activity controller Index Page Route

    app.MapControllerRoute(
    name: "LeadActivity",
    pattern: "{controller=LeadActivity}/{action=Index}/{id?}");


//SalesPerson controller Index Page Route

app.MapControllerRoute(
    name: "SalesPeople",
    pattern: "{controller=SalesPerson}/{action=Index}/{id?}");

app.Run();
