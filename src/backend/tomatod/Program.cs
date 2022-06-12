using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Identity.Web;
using tomatod;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));
builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapHub<DeviceHub>("/deviceHub");

app.MapGet("/status", (HttpContext httpContext) =>
{
})
.WithName("Get status");

app.MapPost("/greenhouse/water", async ([FromServices] IHubContext<DeviceHub> deviceHub) => {
    await deviceHub.Clients.All.SendAsync("water-plants");
})
.WithName("Water plants");

app.MapPost("/greenhouse/shutter/open", async ([FromServices] IHubContext<DeviceHub> deviceHub) => {
    await deviceHub.Clients.All.SendAsync("open-shutter");
})
.WithName("Open shutter");

app.MapPost("/greenhouse/shutter/close", async ([FromServices] IHubContext<DeviceHub> deviceHub) => {
    await deviceHub.Clients.All.SendAsync("close-shutter");
})
.WithName("Close shutter");

app.Run();
