using Rosewood.MVC.Startup;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("Database");

builder.Services.RegisterServices(connectionString);

var app = builder.Build();
app.Inject();

app.Run();
