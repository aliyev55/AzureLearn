
using Microsoft.ApplicationInsights.Extensibility;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Logging & Application Insights
builder.Services.AddLogging(logging => logging.AddConsole());
// builder.Services.AddApplicationInsightsTelemetry();

// DI example
builder.Services.AddSingleton<IGuidService, GuidService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
//     options =>
// {
//     // Optional: Customize the Swagger document metadata
//     options.SwaggerDoc("v1", new OpenApiInfo
//     {
//         Version = "v1",
//         Title = "My API Title",
//         Description = "A description of my API",
 
//     });

// }
);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "AzureDemoApi API V1");
    c.RoutePrefix = ""; // make Swagger available at root URL
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
