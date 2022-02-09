using My2Cents.DataInfrastructure;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("connectionString");


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<My2CentsContext>(options =>
{
    // logging to console is on by default
    options.UseSqlServer(connectionString);
});

builder.Services.AddScoped<IRepository, EfRepository>();

builder.Services.AddCors(options =>
{
    // here you put all the origins that websites making requests to this API via JS are hosted at
    options.AddDefaultPolicy(builder =>
        builder
            .WithOrigins("http://127.0.0.1:5500",
                         "https://my-example-website.azurewebsites.net", "http://localhost:4200")
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials());
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
