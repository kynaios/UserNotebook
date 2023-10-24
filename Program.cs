using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using UserNotebook;
using UserNotebook.Context;
using UserNotebook.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Load environment variables (copy .env file)
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables()
    .Build();

// Add services to the container.
// AutoMapper
var mapper = new MapperConfiguration(c =>
{
    c.AddProfile(new MapperProfile());
}).CreateMapper();
builder.Services.AddSingleton(mapper);

// builder.Services.AddTransient<ICrudRepository<Adult>, AdultRepository>();
// builder.Services.AddTransient<ICrudService<AdultDto>, AdultService>();
// builder.Services.AddTransient<ICrudRepository<Kid>, KidRepository>();
// builder.Services.AddTransient<ICrudService<KidDto>, KidService>();

builder.Services.AddScoped(typeof(ICrudRepository<>), typeof(CrudRepository<>));
builder.Services.AddScoped(typeof(ICrudService<,>), typeof(CrudService<,>));

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UserContext>(options =>
{
    var databaseUser = configuration["USER_NOTEBOOK_DATABASE_USER"];
    var databasePassword = configuration["USER_NOTEBOOK_DATABASE_PASSWORD"];
    
    var dataSourceBuilder =
        new NpgsqlDataSourceBuilder($"Host=localhost; Database=user_notebook; Username={databaseUser}; Password={databasePassword}");
    var dataSource = dataSourceBuilder.Build();
    
    options.UseNpgsql(dataSource);
});

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
