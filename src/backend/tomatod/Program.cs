using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Identity.Web;
using tomatod;
using tomatod.API;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder => builder
    .AllowCredentials()
    .WithOrigins("http://localhost:8080", "https://localhost:5001")
    .AllowAnyMethod()
    .AllowAnyHeader()
));
builder.Services.AddHostedService<MqttListener>();
builder.Services.AddTransient<Greenhouse>();
builder.Services.AddSingleton<GreenhouseStateManager>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseStaticFiles(new StaticFileOptions { FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/dist"))});

app.UseAuthentication();
app.UseAuthorization();

app.MapFallbackToFile("dist/index.html");

app.MapHub<TelemetryHub>("/telemetry-hub");

app.MapGet("/status", (HttpContext httpContext) =>
{
})
.WithName("Get status");

app.MapPost("/api/greenhouse/water", async ([FromServices] Greenhouse greenhouse) => await greenhouse.WaterPlants())
.WithName("Water plants");

app.MapPost("/api/greenhouse/shutter/open", async ([FromServices] Greenhouse greenhouse) => await greenhouse.OpenShutter())
.WithName("Open shutter");

app.MapPost("/api/greenhouse/shutter/close", async ([FromServices] Greenhouse greenhouse) => await greenhouse.CloseShutter())
.WithName("Close shutter");

app.Run();

