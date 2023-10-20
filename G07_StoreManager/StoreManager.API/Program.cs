using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Diagnostics;
using Serilog;
using StoreManager.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();

builder.Logging.AddSerilog(logger);

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

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.UseExceptionHandler(appError =>
{
	appError.Run(async context =>
	{
		context.Response.StatusCode = (int) HttpStatusCode.InternalServerError;
		context.Response.ContentType = "application/json";

		var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
		if (contextFeature != null)
		{
			logger.Error(contextFeature.Error, "Application Error");
			await context.Response.WriteAsync(
				new ErrorDetails(context.Response.StatusCode, "Internal Server Error."
				).ToString());
		}
	});
});

app.Run();

internal sealed record ErrorDetails(int StatusCode, string Message)
{
	public override string ToString() => JsonSerializer.Serialize(this);
}
