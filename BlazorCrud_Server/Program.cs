using BlazorCrud_Server.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adding dabatase context
builder.Services.AddDbContext<DbBlazorwebapicrud1Context>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SQLString"));
});

// Adding Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy", app =>
    {
        app.AllowAnyOrigin()
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Actived Cors
app.UseCors("NewPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
