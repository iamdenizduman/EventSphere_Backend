using EventSphere.Identity.Persistence;
using EventSphere.Identity.Infrastructure;
using EventSphere.Identity.Application;
using EventSphere.Identity.Application.Models.Authentication;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<TokenOptions>(builder.Configuration.GetSection("TokenOptions"));

// CORS
// CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()      // Tüm kaynaklara izin
              .AllowAnyMethod()      // Tüm HTTP metodlara izin
              .AllowAnyHeader();     // Tüm headerlara izin
    });
});


builder.Services.AddPersistenceServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddApplicationServices();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
