using MediatR;
using Microsoft.OpenApi.Models;
using System.Configuration;
using System.Reflection;
using Trainings.Infa.Options;
using Trainings.Infa.Repositories;
using Microsoft.Extensions.Configuration;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "DP_Example", Version = "v1" });
});

IConfiguration Configuration = builder.Configuration;

IServiceCollection serviceCollection = builder.Services.Configure<TrainingDbConfig>(Configuration);

builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddSingleton<ITraining, TrainingContext>();
//services.AddTransient<ITrainingRepository, TrainingRepository>();



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
