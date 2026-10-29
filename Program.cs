using AppointmentSystem.Data;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

// Program.cs has two phases, and the order matters:
// 1. Before builder.Build() you register services. A service is any object the app might need
//    (controllers, the database context, OpenAPI generation). Registering puts it in the dependency
//    injection container.
// 2. After Build() you configure the middleware pipeline. Each request flows through those lines in order,
//    like a conveyer belt, and each step can handle the request or pass it on. 

var builder = WebApplication.CreateBuilder(args);

// REGISTER SERVICES

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddOpenApi();

var app = builder.Build();

// CONFIGURE THE MIDDLEWARE PIPELINE

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();            
    app.MapScalarApiReference(); // test page at /scalar
}

app.UseHttpsRedirection();

// Serve wwwroot/index.html at the site root
app.UseDefaultFiles();
app.UseStaticFiles();

app.UseAuthorization();
app.MapControllers();

app.Run();