using MediatR;
using RentingMicroservice.Api.Models;
using RentingMicroservice.Application;
using RentingMicroservice.Application.Commands;
using RentingMicroservice.Application.DTOs;
using RentingMicroservice.Application.Handlers;
using RentingMicroservice.Application.Interfaces;
using RentingMicroservice.Application.Queries;
using RentingMicroservice.Application.Services;
using RentingMicroservice.Domain.Interfaces;
using RentingMicroservice.Infrastructure;
using RentingMicroservice.Infrastructure.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddTransient<IRequestHandler<AddVehicleCommand, bool>, AddVehicleCommandHandler>();
builder.Services.AddTransient<IRequestHandler<RentVehicleCommand, bool>, RentVehicleCommandHandler>();
builder.Services.AddTransient<IRequestHandler<ReturnVehicleCommand, bool>, ReturnVehicleCommandHandler>();
builder.Services.AddTransient<IRequestHandler<ListVehiclesQuery, List<VehicleDto>>, ListVehiclesQueryHandler>();
builder.Services.AddTransient<IRentingService, RentingService>();
builder.Services.AddTransient<IValidationService, ValidationService>();

builder.Services.AddTransient<IVehicleRepository, VehicleRepository>();

var settings = builder.Configuration.GetSection("RentingDatabase").Get<RentingDatabaseSettings>();

builder.Services.AddScoped<MongoDbContext>(serviceProvider => new MongoDbContext(settings.ConnectionString, settings.DatabaseName));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
