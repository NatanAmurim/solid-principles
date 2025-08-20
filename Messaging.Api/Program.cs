using Messaging.Api.Application;
using Messaging.Api.Domain.Infra;
using Messaging.Api.Infra;
using Messaging.Worker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<ChannelFactory>();
builder.Services.AddScoped<IOrderMessagingBroker, OrderRabbitMQBroker>();
builder.Services.AddScoped<OrderMessagingHandler>();
builder.Services.AddHostedService<Worker>();

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
