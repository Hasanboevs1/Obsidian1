using Microsoft.EntityFrameworkCore;
using Obsidian.Data.DbContexts;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connection = builder.Configuration.GetConnectionString("obs");

builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(connection);
});


builder.Services.AddAutoMapper(typeof(MappingProfile));



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
