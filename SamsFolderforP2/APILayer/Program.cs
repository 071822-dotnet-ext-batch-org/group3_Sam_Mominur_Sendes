using BusinessLayer;
using Microsoft.AspNetCore.DataProtection.Repositories;
using RepoLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args); 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IBusiness, Business>();
builder.Services.AddScoped<IRepo, Repo>();
string v = builder.Configuration["ConnectionStrings:DefaultConnection"];
// here we store our services like BUSINESS LAYERS => REPO LAYERS and MODELS
//DEPENDENCY INJECTION, when we terst it we use Interfaces

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); //middleware

app.UseRouting();

app.MapControllers();

app.Run();
