using Microsoft.EntityFrameworkCore;
using Obsidian.Api.Extensions;
using Obsidian.Data.DbContexts;
using Obsidian.Service.Mappings;
using Serilog;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var connection = builder.Configuration.GetConnectionString("obs");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(connection);
});


builder.Services.AddCustomService();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Logging
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
