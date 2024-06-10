namespace Northwind.API.Models;

public class Currency
{
    public int Unit { get; }

    public string Name { get;}

    public decimal ForexBuying { get; }

    public decimal ForexSelling { get; }

    public Currency(
        int unit,
        string name,
        decimal forexBuying,
        decimal forexSelling)
    {
        Unit = unit;
        Name = name;
        ForexBuying = forexBuying;
        ForexSelling = forexSelling;
    }
}
