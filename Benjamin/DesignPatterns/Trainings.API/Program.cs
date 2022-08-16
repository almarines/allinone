using Trainings.Domain.Repositories;
using Trainings.Domain.Repositories.Context;
using Trainings.Infra.Context;
using Trainings.Infra.Repositories;
using MediatR;
using Trainings.Infra.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<DbConfig>(builder.Configuration);

builder.Services.AddMediatR(typeof(Program));

builder.Services.AddSingleton<ILiteDBContext, LiteDbContext>();
builder.Services.AddTransient<ITrainingRepository, TrainingRepository>();

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
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
app.Run();
