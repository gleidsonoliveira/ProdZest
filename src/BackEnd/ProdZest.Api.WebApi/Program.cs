using ProdZest.Api.CrossCutting.DependencyInjection.AutoMapper;
using ProdZest.Api.CrossCutting.DependencyInjection.DbConfig;
using ProdZest.Api.CrossCutting.DependencyInjection.Repository;
using ProdZest.Api.CrossCutting.DependencyInjection.Service;
using ProdZest.Api.CrossCutting.DependencyInjection.Validation.Base;
using ProdZest.Api.Data.Context;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region IOC
builder.Services.AddMemoryDatabaseDependency(builder.Configuration);
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddMapperConfiguration();
builder.Services.AddValidators();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// global cors policy
app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseSwagger();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api Denso");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();