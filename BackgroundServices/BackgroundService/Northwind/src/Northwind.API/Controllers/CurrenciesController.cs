using Microsoft.AspNetCore.Mvc;
using Northwind.API.Models;

namespace Northwind.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurrenciesController : ControllerBase
{
    [HttpGet]
    public IActionResult GetList()
    {
       return Ok(new { CurrentExchangeRates.Currencies, CurrentExchangeRates .LastUpdateDate});
    }

    [HttpGet("{name}")]
    public IActionResult GetByName(string name)
    {
        var currencies = CurrentExchangeRates.GetByName(name);
        return Ok(new { currencies, CurrentExchangeRates.LastUpdateDate });
    }
}
