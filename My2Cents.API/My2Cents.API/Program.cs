using My2Cents.DataInfrastructure;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("connectionString");

IRepository repository = new EfRepository(connectionString);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();
