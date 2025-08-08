using CacheDemo.Application;
using CacheDemo.Domain.Infra;
using CacheDemo.Infra;
using CacheDemo.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<ProductHandler>();
builder.Services.AddScoped<ProductCacheHandler>();
builder.Services.AddKeyedScoped<IProductCache, MemoryProductCache>(Constants.PRODUCT_MEMORY_CHACHE);
builder.Services.AddKeyedScoped<IProductCache, RedisProductCache>(Constants.PRODUCT_DISTRIBUITED_CACHE);

builder.Services.AddMemoryCache();

// Redis (IDistributedCache)
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost:6379"; // ajuste se necessário
    options.InstanceName = "CacheDemo:";
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
