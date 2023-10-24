using Serilog;
using StoreManager.API.Configuration;
using StoreManager.API.ExceptionHandler;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

Log.Logger.ConfigureLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers();

builder.ConfigureDependency(configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.HandleException();

app.Run();
