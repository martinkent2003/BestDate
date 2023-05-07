using API.Extensions;
using API.MIddleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationsServices(builder.Configuration);
builder.Services.AddIdentityServices(builder.Configuration);
var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();
//Configure the HTTP request pipeline
app.UseCors(builder => builder.AllowAnyHeader().AllowAnyMethod()
    .WithOrigins("https://localhost:4200"));
//checking for token
app.UseAuthentication();
//checking what toke authors for 
app.UseAuthorization();

app.MapControllers();

app.Run();
