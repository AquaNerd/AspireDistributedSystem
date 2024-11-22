using AspireDistributedSystem.ApiService.Controllers.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace AspireDistributedSystem.ApiService.Controllers;

public class FinancialForecastController : BaseApiController
{
    // GET: api/<FinancialForecastController>
    [HttpGet]
    public IEnumerable<string> Get()
    {
        return new string[] { "value1", "value2" };
    }

    // GET api/<FinancialForecastController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<FinancialForecastController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<FinancialForecastController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<FinancialForecastController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
