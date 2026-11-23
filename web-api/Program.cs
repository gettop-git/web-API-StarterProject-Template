using Microsoft.EntityFrameworkCore;
using Repositories;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddDbContext<MyStorDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(
    "Data Source=srv2\\pupils;Initial Catalog=MyStorDB;Integrated Security=True;Trust Server Certificate=True")), ServiceLifetime.Transient);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
