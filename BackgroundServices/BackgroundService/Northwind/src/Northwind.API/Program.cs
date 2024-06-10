using Northwind.API.BackgroundServices;
using Northwind.API.Interfaces;
using Northwind.API.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<IExchangeRateClient, TCMBExchangeRateClient>(options =>
{
    options.BaseAddress = new Uri("https://www.tcmb.gov.tr");
});

builder.Services.AddHostedService<ExchangeRateCheckerBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
