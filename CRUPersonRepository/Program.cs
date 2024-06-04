using CRUPersonRepository.Context;
using CRUPersonRepository.Repository;
using CRUPersonRepository.Repository.Interface;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Variable de conexion
var connectionString = builder.Configuration.GetConnectionString("Connection");
// Registramos el servicio para la conexión
builder.Services.AddDbContext<AppDBContext>(options => options.UseSqlServer(connectionString));
// Agregamos el repositorio
builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Add services to the container.
builder.Services.AddControllers();
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
