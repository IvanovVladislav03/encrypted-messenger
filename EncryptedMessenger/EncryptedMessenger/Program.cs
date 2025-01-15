using Microsoft.EntityFrameworkCore;
using System;
using EncryptedMessenger.Infrastructure.Persistence;
using EncryptedMessenger.Application.Servicies;
using Microsoft.Extensions.Configuration;
using EncryptedMessenger.Application.Configuration;
using EncryptedMessenger.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;






services.AddControllers();


services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

services.AddApplication(builder.Configuration);
services.AddInfrastructure(builder.Configuration);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
