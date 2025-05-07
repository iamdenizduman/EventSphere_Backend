using EventSphere.PaymentService.Persistence;
using EventSphere.PaymentService.Application;
using EventSphere.PaymentService.Infrastructure;
using EventSphere.PaymentService.Infrastructure.Configurations;


var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<IyzicoPaymentSettings>(
    builder.Configuration.GetSection("IyzicoPaymentSettings"));

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddPersistenceServices();

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

app.UseAuthorization();

app.MapControllers();

app.Run();
