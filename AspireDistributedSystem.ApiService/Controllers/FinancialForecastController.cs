using AspireDistributedSystem.ApiService.Auth;
using AspireDistributedSystem.ApiService.Controllers.Abstractions;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<FinancialForecastController>/5
    [HttpPut("{id}")]
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<FinancialForecastController>/5
    [HttpDelete("{id}")]
    [Authorize(Policy = IdentityData.AdminUserPolicyName)]
    public void Delete(int id)
    {
    }
}
