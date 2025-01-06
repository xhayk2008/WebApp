using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebApp.BLL.Interfaces;
using WebApp.BLL.Services;
using WebApp.DAL;
using WebApp.DAL.Interfaces;
using WebApp.DAL.Repository;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("AppDb")));

builder.Services.AddScoped<IAppRepository, AppRepository>();
builder.Services.AddScoped<IAppService, AppService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    var url = "http://localhost:5288/swagger";
    var psi = new ProcessStartInfo
    {
        FileName = url,
        UseShellExecute = true
    };
    Process.Start(psi);

    app.MapOpenApi();
}

app.MapControllers();

app.Run();
