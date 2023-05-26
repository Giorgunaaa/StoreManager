using StoreManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Configure DI
builder.Services.AddTransient<INumberGenerator, NumberGeneratorService>();
//builder.Services.AddScoped<INumberGenerator, NumberGeneratorService>();
//builder.Services.AddSingleton<INumberGenerator, NumberGeneratorService>();
//builder.Services.AddSingleton<INumberGenerator>(sp => new NumberGeneratorService());

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
