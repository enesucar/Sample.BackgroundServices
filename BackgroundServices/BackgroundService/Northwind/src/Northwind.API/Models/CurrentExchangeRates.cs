namespace Northwind.API.Models;

public class CurrentExchangeRates
{
    public static List<Currency> Currencies { get; set; } = [];

    public static DateTime LastUpdateDate { get; set; }

    public static Currency? GetByName(string name)
    {
        return Currencies.FirstOrDefault(o => o.Name == name);
    }
}
