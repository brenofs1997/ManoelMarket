using CL.WebApi.Configuration;
using GM.Data.Context;
using GM.Data.Repository;
using GM.Data.Services;
using GM.Manager.Implementation;
using GM.Manager.Interfaces.Managers;
using GM.Manager.Interfaces.Repositories;
using GM.Manager.Interfaces.Services;
using GM.WebApi.Configuration;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddScoped<IPedidoService, PedidoService>();
builder.Services.AddScoped<IPedidoRepository, PedidoRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPedidoManager, PedidoManager>();
builder.Services.AddScoped<IUserManager, UserManager>();
builder.Services.AddControllers();
builder.Services.AddJwtTConfiguration(configuration);
builder.Services.AddDatabaseConfiguration(configuration);
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddSwaggerConfiguration();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
