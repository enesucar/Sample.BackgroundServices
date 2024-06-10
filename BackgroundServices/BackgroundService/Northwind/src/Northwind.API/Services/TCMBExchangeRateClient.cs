using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Northwind.API.Interfaces;
using Northwind.API.Models;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Northwind.API.Services;

public class TCMBExchangeRateClient : IExchangeRateClient
{
    private readonly HttpClient _httpClient;

    public TCMBExchangeRateClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Currency>> GetExchangeRatesAsync()
    { 
        var httpResponseMessage = await _httpClient.GetAsync("/kurlar/today.xml");
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.LoadXml(await httpResponseMessage.Content.ReadAsStringAsync());
        XmlNodeList currencies = xmlDocument.SelectNodes("/Tarih_Date/Currency")!;
        return currencies
            .Cast<XmlNode>()
            .Select(xmlNode => new Currency(
                GetValue<int>(xmlNode, "Unit"),
                GetValue<string>(xmlNode, "CurrencyName")!,
                GetValue<decimal>(xmlNode, "ForexBuying"),
                GetValue<decimal>(xmlNode, "ForexSelling"))
            ).ToList();
    }

    private T? GetValue<T>(XmlNode xmlNode, string name)
        where T : IConvertible
    {
        var text = xmlNode.SelectSingleNode(name)?.InnerText;
        if (string.IsNullOrEmpty(text))
        {
            return default;
        }

        return (T)Convert.ChangeType(text, typeof(T));
    } 
}
