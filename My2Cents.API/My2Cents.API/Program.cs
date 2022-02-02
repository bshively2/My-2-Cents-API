var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("connectionString");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
