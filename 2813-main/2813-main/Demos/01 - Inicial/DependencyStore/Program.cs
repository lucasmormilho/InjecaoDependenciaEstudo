
using DependencyStore;
using DependencyStore.Extensions;
using DependencyStore.Repositorios;
using DependencyStore.Repositorios.Contratos;
using DependencyStore.Servicos;
using DependencyStore.Servicos.Contratos;
using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSingleton<Configuration>();
var connStr = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSqlConnection(connStr);
builder.Services.AddRepositories();
builder.Services.AddServices();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();