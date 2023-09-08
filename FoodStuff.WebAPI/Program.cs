using FoodStuff.DAL;
using FoodStuff.Domain.Abstraction;
using FoodStuff.Service.FoodVendors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFoodVendorRepository, FoodVendorRepository>();
builder.Services.AddScoped<IFoodVendorService, FoodVendorService>();

static string TryGetSolutionDirectoryInfo(string currentPath = null)
{
    var directory = new DirectoryInfo(
        currentPath ?? Directory.GetCurrentDirectory());
    while (directory != null && !directory.GetFiles("FoodStuff.sln").Any())
    {
        directory = directory.Parent;
    }
    return directory?.FullName;
}

// get directory
var solutionDirectory = TryGetSolutionDirectoryInfo();
// if directory found

builder.Services.AddDbContext<DataContext>(options => {

    // Construct the full path to the database file
    var databaseFilePath = Path.Combine(solutionDirectory, "FoodStuff.DAL", "Database", "FoodStuffDB.mdf");

    string conn = builder.Configuration.GetConnectionString("DefaultConnection");
    if (conn.Contains("%CONTENTROOTPATH%"))
    {
        conn = conn.Replace("%CONTENTROOTPATH%", databaseFilePath);
    }

    // Use the modified connection string
    options.UseSqlServer(conn);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options =>
//options.WithOrigins("http://localhost:61402")
 options.WithOrigins("*")
.AllowAnyMethod()
.AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


