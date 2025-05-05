using EventSphere.Core.Repository.Abstract.MongoDb;
using EventSphere.StockService.Business.Abstract;
using EventSphere.StockService.Business.Concrete;
using EventSphere.StockService.Business.Consumers;
using EventSphere.StockService.DataAccess.Abstract;
using EventSphere.StockService.DataAccess.Concrete.MongoDb;
using MassTransit;

var builder = WebApplication.CreateBuilder(args);


// ioc
builder.Services.AddScoped(provider =>
    new MongoDbService("mongodb://localhost:27017", "EventSphere_StockServiceDb"));

builder.Services.AddScoped<IStockRepository, MdbStockRepository>();
builder.Services.AddScoped<IStockHistoryRepository, MdbStockHistoryRepository>();
builder.Services.AddScoped<IStockHistoryService, StockHistoryService>();
builder.Services.AddScoped<IStockService, StockService>();

// masstransit rabbitMQ
builder.Services.AddMassTransit(confg =>
{
    confg.AddConsumer<EventCreatedEventConsumer>();
    confg.AddConsumer<OrderCreatedEventConsumer>();
    confg.UsingRabbitMq((context, _confg) =>
    {
        _confg.Host(builder.Configuration["RabbitMQ"]);
        _confg.ReceiveEndpoint("event-service-created-event-queue", e =>
        {
            e.ConfigureConsumer<EventCreatedEventConsumer>(context);
        });
        _confg.ReceiveEndpoint("order-service-created-order-queue", e =>
        {
            e.ConfigureConsumer<OrderCreatedEventConsumer>(context);
        });
    });
});


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
