using Microsoft.ApplicationInsights.Extensibility;


var builder = WebApplication.CreateBuilder(args);

// Logging & Application Insights
builder.Services.AddLogging(logging => logging.AddConsole());
// builder.Services.AddApplicationInsightsTelemetry();

// DI example
builder.Services.AddSingleton<IGuidService, GuidService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

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

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
