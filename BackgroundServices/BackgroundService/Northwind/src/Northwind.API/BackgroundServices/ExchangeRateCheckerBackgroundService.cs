using Northwind.API.Interfaces;
using Northwind.API.Models;

namespace Northwind.API.BackgroundServices;

public class ExchangeRateCheckerBackgroundService : BackgroundService
{
    private readonly IExchangeRateClient _exchangeRateClient;

    public ExchangeRateCheckerBackgroundService(IExchangeRateClient exchangeRateClient)
    {
        _exchangeRateClient = exchangeRateClient;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (true)
        {
            var currentExchangeRates = await _exchangeRateClient.GetExchangeRatesAsync();
            CurrentExchangeRates.Currencies = currentExchangeRates.ToList();
            CurrentExchangeRates.LastUpdateDate = DateTime.Now;
            await Task.Delay(10000);
        }
    }
}
