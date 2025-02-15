﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OfferAPI;
using OfferAPI.Data;
using OfferAPI.Interfaces;
using OfferAPI.Repositories;
using System;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<OfferAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OfferAPIContext") ?? throw new InvalidOperationException("Connection string 'OfferAPIContext' not found.")));

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddTransient<Seed>();
builder.Services.AddTransient<IOfferRepository, OfferRepository>();
builder.Services.AddTransient<ISupplierRepository, SupplierRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
    SeedData(app);

void SeedData(IHost app)
{
    var scopedFactory = app.Services.GetService<IServiceScopeFactory>();

    using (var scope = scopedFactory.CreateScope())
    {
        var service = scope.ServiceProvider.GetService<Seed>();
        service.SeedDataContext();
    }
}


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
