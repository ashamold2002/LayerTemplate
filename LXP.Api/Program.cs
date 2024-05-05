using LXP.Core.Services;
using LXP.Core.IServices;
using Serilog;
using LXP.Data.IRepository;
using LXP.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IServices,Services>();
builder.Services.AddScoped<IRepository,Repository>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
Log.Logger=new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration).CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
