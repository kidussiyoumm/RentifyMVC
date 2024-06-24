using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using RentifyMVC.Data;
using RentifyMVC.Repository.Implementation;
using RentifyMVC.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//This is debendancy injection. We use builder services to connect the Db connection string from appsetting 
builder.Services.AddDbContext<RentifyDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("RentifyConnectionString"));
});

// Register Swagger services
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Rentify API", Version = "v1" });
    // Additional Swagger configuration (e.g., security definitions) can be added here
});

builder.Services.AddScoped<IProperty, PropertyRepository>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rentify API V1");
        // Additional Swagger UI configuration can be added here
    });
}
else
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
