using OnBoarding.api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var app = builder.ConfigureServices().Configure();

app.Run();
