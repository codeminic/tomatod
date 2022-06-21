using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web;
using tomatod;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();
builder.Services.AddHostedService<MqttListener>();

builder.Services.AddTransient<Greenhouse>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/status", (HttpContext httpContext) =>
{
})
.WithName("Get status");

app.MapPost("/greenhouse/water", async ([FromServices] Greenhouse greenhouse) => await greenhouse.WaterPlants())
.WithName("Water plants");

app.MapPost("/greenhouse/shutter/open", async ([FromServices] Greenhouse greenhouse) => await greenhouse.OpenShutter())
.WithName("Open shutter");

app.MapPost("/greenhouse/shutter/close", async ([FromServices] Greenhouse greenhouse) => await greenhouse.CloseShutter())
.WithName("Close shutter");

app.Run();

