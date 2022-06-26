using Infrastructure.Persistance;
using Infrastructure.Persistance.DIContainer;
using Application.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
//DbRegistration
builder.Services.AddDbServices(configuration);
//DI Container
builder.Services.AddDIServices();
//MediatR and Automapper
builder.Services.AddApplicationServices();
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
//Auth
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
