using AutoMapper;
using EmployeeRegistratation.Api.DTOs;
using EmployeeRegistratation.Domain.Entities;
using EmployeeRegistration.Application.DI;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

Initializer.Configure(builder.Services, builder.Configuration.GetConnectionString("DefaultConnection"));

var config = new AutoMapper.MapperConfiguration(cfg =>
{
    cfg.CreateMap<Employee, EmployeeDto>();
});
IMapper mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()); });

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Employees Api", Version = "v1" }); ;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

