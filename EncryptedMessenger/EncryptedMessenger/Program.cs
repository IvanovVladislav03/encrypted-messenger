using Microsoft.EntityFrameworkCore;
using System;
using EncryptedMessenger.Infrastructure.Persistence;
using EncryptedMessenger.Application.Servicies;
using Microsoft.Extensions.Configuration;
using EncryptedMessenger.Application.Configuration;
using EncryptedMessenger.Infrastructure.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using EncryptedMessenger.WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;



services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5173");
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowCredentials();
    });
});

services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        var jwtOptions = builder.Configuration.GetSection(nameof(JwtSettings)).Get<JwtSettings>();
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                System.Text.Encoding.UTF8.GetBytes(jwtOptions.Secret))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["cookies-token"];

                return Task.CompletedTask;
            }
        };
    });

services.AddAuthorization();

services.AddControllers();


services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

services.AddApplication(builder.Configuration);
services.AddInfrastructure(builder.Configuration);

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();
services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
    
app.MapControllers();

app.MapHub<ChatHub>("/chat");

app.Run();
