using Northwind.API.Models;

namespace Northwind.API.Interfaces;

public interface IExchangeRateClient
{
    Task<IEnumerable<Currency>> GetExchangeRatesAsync();
}
