using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3.Data;
using Lab3.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Настройка служб
builder.Services.AddDbContext<ModelDB>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            // Параметры валидации токена...
        };
    });

builder.Services.AddAuthorization();
var app = builder.Build();

// Промежуточное ПО
app.UseAuthentication();
app.UseAuthorization();

// API эндпоинты
app.MapGet("api/tariffs", async (ModelDB db) => await db.Tariffs.ToListAsync());
app.MapGet("api/tariffs/{id:int}", async (int id, ModelDB db) =>
{
    var tariff = await db.Tariffs.FindAsync(id);
    return tariff is not null ? Results.Json(tariff) : Results.NotFound();
});

app.MapGet("api/callrecords", async (ModelDB db) => await db.CallRecords.ToListAsync());
app.MapPost("api/callrecords", async (CallRecord callRecord, ModelDB db) =>
{
    await db.CallRecords.AddAsync(callRecord);
    await db.SaveChangesAsync();
    return Results.Json(callRecord);
});

// Другие операции CRUD...

app.Run();