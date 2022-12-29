using Microsoft.EntityFrameworkCore;
using BuberBreakfast.Services.Breakfasts;
using BuberBreakfast.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<IBreakfastService, BreakfastService>();

builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<BreakfastContext>(
        options => options.UseSqlServer(builder.Configuration.GetConnectionString("DataBase")));

var app = builder.Build();
{   
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();

}

