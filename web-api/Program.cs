using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
//builder.Services.AddDbContext<MyStorDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(
//    "Data Source=srv2\\pupils;Initial Catalog=MyStorDB;Integrated Security=True;Trust Server Certificate=True")), ServiceLifetime.Transient);
builder.Services.AddDbContext<MyStorDBContext>(options => options.UseSqlServer(
    "Data Source=localhost;Initial Catalog=MyStorDB;Integrated Security=True;Trust Server Certificate=True"), ServiceLifetime.Transient);
builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
builder.Services.AddTransient<IProductsService, ProductsService>();
builder.Services.AddTransient<ICategoriesRepository, CategoriesRepository>();
builder.Services.AddTransient<ICategoriesService, CategoriesService>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddOpenApi();
var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
