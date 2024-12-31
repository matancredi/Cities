using NLog.Web;
using ReactApp1.Server.Domain.Interfaces;
using ReactApp1.Server.Infra;
using ReactApp1.Server.Infra.Repositories;
using ReactApp1.Server.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<IStateService, StateService>();
builder.Services.AddScoped<IStateRepository, StateRepository>();

builder.Host.ConfigureLogging(
    log =>
    {
        log.ClearProviders()
            .AddFilter("Microsoft", LogLevel.Warning)
            .AddFilter("System", LogLevel.Warning);
    }).UseNLog();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
