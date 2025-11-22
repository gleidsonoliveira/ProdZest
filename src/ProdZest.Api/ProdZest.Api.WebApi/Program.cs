using ProdZest.Api.CrossCutting.DependencyInjection.AutoMapper;
using ProdZest.Api.CrossCutting.DependencyInjection.DbConfig;
using ProdZest.Api.CrossCutting.DependencyInjection.Repository;
using ProdZest.Api.CrossCutting.DependencyInjection.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddMemoryDatabaseDependency(builder.Configuration);
builder.Services.AddRepositoryDependency();
builder.Services.AddServiceDependency();
builder.Services.AddMapperConfiguration();


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
